using AutoMapper;
using HRM.Application.UseCases.Users.DTOs;
using HRM.Application.UseCases.Users.Services;
using HRM.Application.UseCases.Auth.DTOs;
using HRM.Domain.Entities;
using HRM.Domain.Entities.Users;
using HRM.Domain.Exceptions;
using HRM.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRM.Application.UseCases.Users.Commands;

public class CreateUserCommandHandler(UserManager<User> userManager, IMapper mapper, RoleService roleService)
    : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User { Email = request.Email, UserName = request.Username };
        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded) throw new BadRequestException("Failed to create user");

        await roleService.AddRoleToUser(user, request.Roles);

        var dto = mapper.Map<UserDto>(user);

        return dto;
    }
}