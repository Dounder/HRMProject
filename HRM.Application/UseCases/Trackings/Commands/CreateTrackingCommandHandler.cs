using HRM.Domain.Entities.Trackings;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Trackings.Commands;

public class CreateTrackingCommandHandler(IUnitOfWork repository) : IRequestHandler<CreateTrackingCommand, Unit>
{
    public async Task<Unit> Handle(CreateTrackingCommand request, CancellationToken cancellationToken)
    {
        var track = new TimeTracking { EmployeeId = request.EmployeeId, TimeIn = request.TimeIn };

        await repository.TimeTracking.Add(track);

        await repository.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}