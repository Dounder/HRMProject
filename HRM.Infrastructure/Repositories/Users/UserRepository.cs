using AutoMapper;
using HRM.Domain.Entities.Users;
using HRM.Domain.Interfaces.Users;
using HRM.Infrastructure.Data;
using HRM.Infrastructure.Repositories.Common;

namespace HRM.Infrastructure.Repositories.Users;

public class UserRepository(ApplicationDbContext context, IMapper mapper) : BaseRepository<User>(context, mapper), IUserRepository
{
}