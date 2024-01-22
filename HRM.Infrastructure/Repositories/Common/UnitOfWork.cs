using AutoMapper;
using HRM.Domain.Interfaces.Common;
using HRM.Domain.Interfaces.Employees;
using HRM.Domain.Interfaces.Trackings;
using HRM.Domain.Interfaces.Users;
using HRM.Infrastructure.Data;
using HRM.Infrastructure.Repositories.Employees;
using HRM.Infrastructure.Repositories.Trackings;
using HRM.Infrastructure.Repositories.Users;

namespace HRM.Infrastructure.Repositories.Common;

public class UnitOfWork(ApplicationDbContext context, IMapper mapper) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken);

    public void Dispose() => context.Dispose();

    #region Users

    public IUserRepository User => new UserRepository(context, mapper);

    #endregion

    #region Employee

    public IEmployeeRepository Employee => new EmployeeRepository(context, mapper);
    public IDepartmentRepository Department => new DepartmentRepository(context, mapper);
    public IPositionRepository Position => new PositionRepository(context, mapper);
    public ITimeTrackingRepository TimeTracking => new TimeTrackingRepository(context, mapper);

    #endregion
}