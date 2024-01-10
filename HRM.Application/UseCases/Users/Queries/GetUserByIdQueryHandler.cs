using AutoMapper;
using HRM.Application.UseCases.Users.DTOs;
using HRM.Application.UseCases.Users.Services;
using HRM.Domain.Exceptions;
using HRM.Domain.Interfaces;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Users.Queries;

public class GetUserByIdQueryHandler(IUnitOfWork repository, RoleService roleService) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.UserRepository.GetByIdAsyncMap<UserDto>(request.Id);

        if (user == null) throw new NotFoundException($"User not found");

        if (user.DeletedAt != null) throw new NotFoundException($"User inactive, please contact the administrator");

        user.Roles = await roleService.GetAllRoles<RoleDto>(user.Id);

        return user;
    }
}