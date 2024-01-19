using AutoMapper;
using HRM.Domain.Entities.Employees;
using HRM.Domain.Interfaces.Employees;
using HRM.Infrastructure.Data;
using HRM.Infrastructure.Repositories.Common;

namespace HRM.Infrastructure.Repositories.Employees;

public class TimeTrackingRepository(ApplicationDbContext context, IMapper mapper)
    : BaseRepository<TimeTracking>(context, mapper), ITimeTrackingRepository
{
}