using AutoMapper;
using HRM.Domain.Entities.Trackings;
using HRM.Domain.Exceptions;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Trackings.Commands;

public class UpdateTrackCommandHandler(IUnitOfWork repository, IMapper mapper) : IRequestHandler<UpdateTrackCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
    {
        var track = await repository.TimeTracking.GetWhere(x => x.EmployeeId == request.EmployeeId && x.Date == DateTime.Now.Date);

        if (track == null) throw new NotFoundException("The employee does not have a time tracking record today");

        track = mapper.Map(request, track);

        ValidateTime(track);

        if (track is { TimeOut: not null, LunchIn: not null, LunchOut: not null })
            track = CalculateHours(track);

        repository.TimeTracking.Update(track);

        await repository.CommitAsync(cancellationToken);

        return Unit.Value;
    }

    private void ValidateTime(TimeTracking track)
    {
        if (track.TimeIn >= track.TimeOut)
            throw new BadRequestException("The time in must be less than the time out");

        if (track.LunchIn <= track.LunchOut)
            throw new BadRequestException("The lunch in must be after the lunch out");

        if (track.LunchIn <= track.TimeIn)
            throw new BadRequestException("The lunch in must be after the time in");

        if (track.LunchOut >= track.TimeOut)
            throw new BadRequestException("The lunch out must be before the time out");

        if (track.LunchIn >= track.TimeOut || track.LunchOut <= track.TimeIn)
            throw new BadRequestException("The lunch time must be between the time in and time out");

        // TODO: add unrealistic time validation
    }


    private TimeTracking CalculateHours(TimeTracking track)
    {
        if (track is { TimeOut: null, LunchIn: null, LunchOut: null })
            throw new InvalidOperationException("Cannot calculate hours when one or more time entries are missing");

        // Calculate total hours worked (TimeOut - TimeIn - LunchDuration)
        const int standardWorkHours = 8;
        var totalWorkedHours = (TimeSpan)(track.TimeOut - track.TimeIn)!;
        var lunchDuration = (TimeSpan)(track.LunchIn - track.LunchOut)!;
        totalWorkedHours -= lunchDuration;

        track.TotalHours = totalWorkedHours.TotalHours;
        track.TotalExtraHours = Math.Max(0, track.TotalHours - standardWorkHours); // Subtract standard work hours (8 hours)

        if (track.TotalHours < 0 || track.TotalExtraHours < 0)
            throw new InvalidOperationException("The total hours or total extra hours cannot be negative");

        return track;
    }
}