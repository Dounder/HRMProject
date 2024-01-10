using AutoMapper;
using HRM.Application.UseCases.Auth.DTOs;
using HRM.Application.UseCases.Users.DTOs;
using HRM.Application.UseCases.Users.Services;
using HRM.Domain.Entities;
using HRM.Domain.Entities.Users;
using HRM.Domain.Interfaces;
using HRM.Domain.Interfaces.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRM.Application.UseCases.Auth.Commands;

public class LoginCommandHandler(
    SignInManager<User> signInManager,
    ITokenService tokenService,
    IMapper mapper,
    UserService userService,
    RoleService roleService)
    : IRequestHandler<LoginCommand, AuthDto>
{
    public async Task<AuthDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userService.FindUserByNameAsync(request.Username, cancellationToken: cancellationToken);

        if (user == null) throw new UnauthorizedAccessException("Invalid credentials");

        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded) throw new UnauthorizedAccessException("Invalid credentials");

        var userDto = mapper.Map<UserDto>(user);
        userDto.Roles = await roleService.GetAllRoles<RoleDto>(user.Id);

        var accessToken = await tokenService.GenerateAccessToken(user);
        var refreshToken = await tokenService.GenerateRefreshToken(user);

        return new AuthDto { User = userDto, AccessToken = accessToken, RefreshToken = refreshToken };
    }
}