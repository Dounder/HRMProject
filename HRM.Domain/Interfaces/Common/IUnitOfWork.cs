using HRM.Domain.Interfaces.Employees;
using HRM.Domain.Interfaces.Trackings;
using HRM.Domain.Interfaces.Users;

namespace HRM.Domain.Interfaces.Common;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync(CancellationToken cancellationToken = default);

    #region Users

    IUserRepository User { get; }

    #endregion

    #region Employee

    IEmployeeRepository Employee { get; }
    IDepartmentRepository Department { get; }
    IPositionRepository Position { get; }
    ITimeTrackingRepository TimeTracking { get; }

    #endregion
}