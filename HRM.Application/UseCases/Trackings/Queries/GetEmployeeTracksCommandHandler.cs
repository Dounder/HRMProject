using HRM.Application.UseCases.Trackings.DTOs;
using HRM.Domain.Common;
using HRM.Domain.Entities.Trackings;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Trackings.Queries;

public class GetEmployeeTracksCommandHandler(IUnitOfWork repository) : IRequestHandler<GetEmployeeTracksCommand, IEnumerable<TimeTrackingDto>>
{
    public async Task<IEnumerable<TimeTrackingDto>> Handle(GetEmployeeTracksCommand request, CancellationToken cancellationToken)
    {
        var filter = new FilterParams<TimeTracking>
        {
            Pagination = new PaginationParams { Limit = 10000, Offset = 0 },
            Where = x => x.EmployeeId == request.Id && x.Date == DateTime.Now.Date
        };
        var tracks = await repository.TimeTracking.GetAllAsyncMap<TimeTrackingDto>(filter);

        return tracks;
    }
}