using HRM.Application.UseCases.Users.DTOs;
using HRM.Application.UseCases.Users.Services;
using HRM.Domain.Common;
using HRM.Domain.Entities;
using HRM.Domain.Entities.Users;
using HRM.Domain.Interfaces;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Users.Queries;

public class GetUsersQueryHandler(IUnitOfWork repository, RoleService roleService)
    : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var filter = new FilterParams<User> { Pagination = request.Pagination };
        var users = await repository.User.GetAllAsyncMap<UserDto>(filter);

        users = users.Select(x =>
        {
            x.Roles = roleService.GetAllRoles(x.Id).Result;
            return x;
        });

        return users;
    }
}