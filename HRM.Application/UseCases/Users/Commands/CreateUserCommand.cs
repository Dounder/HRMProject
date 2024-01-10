using HRM.Application.UseCases.Users.DTOs;
using HRM.Application.UseCases.Auth.DTOs;
using HRM.Domain.Enums;
using MediatR;

namespace HRM.Application.UseCases.Users.Commands;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public List<string> Roles { get; set; } = [Role.User.ToString()];
}