using AutoMapper;
using HRM.Application.UseCases.Users.DTOs;
using HRM.Application.UseCases.Users.Services;
using HRM.Domain.Entities.Users;
using HRM.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRM.Application.UseCases.Users.Commands;

public class CreateUserCommandHandler(UserManager<User> userManager, IMapper mapper, RoleService roleService)
    : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Email = request.Email, UserName = request.Username, RefreshToken = Guid.NewGuid().ToString(),
            RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(-1)
        };
        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded) throw new BadRequestException("Failed to create user");

        await roleService.AddRoleToUser(user, request.Roles);

        var dto = mapper.Map<UserDto>(user);
        dto.Roles = await roleService.GetAllRoles(user.Id);

        return dto;
    }
}