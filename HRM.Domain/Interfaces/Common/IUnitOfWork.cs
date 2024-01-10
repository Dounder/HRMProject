using HRM.Domain.Interfaces.Users;

namespace HRM.Domain.Interfaces.Common;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    Task CommitAsync();
}