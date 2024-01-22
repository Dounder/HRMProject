using AutoMapper;
using HRM.Domain.Entities.Trackings;
using HRM.Domain.Interfaces.Trackings;
using HRM.Infrastructure.Data;
using HRM.Infrastructure.Repositories.Common;

namespace HRM.Infrastructure.Repositories.Trackings;

public class TimeTrackingRepository(ApplicationDbContext context, IMapper mapper)
    : BaseRepository<TimeTracking>(context, mapper), ITimeTrackingRepository
{
}