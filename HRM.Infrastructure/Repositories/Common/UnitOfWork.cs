using AutoMapper;
using HRM.Domain.Interfaces.Common;
using HRM.Domain.Interfaces.Users;
using HRM.Infrastructure.Data;
using HRM.Infrastructure.Repositories.Users;

namespace HRM.Infrastructure.Repositories.Common;

public class UnitOfWork(ApplicationDbContext context, IMapper mapper) : IUnitOfWork
{
    public IUserRepository UserRepository => new UserRepository(context, mapper);

    public async Task CommitAsync() => await context.SaveChangesAsync();

    public void Dispose() => context.Dispose();
}