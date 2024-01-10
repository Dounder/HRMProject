using HRM.Application.UseCases.Auth.DTOs;
using MediatR;

namespace HRM.Application.UseCases.Auth.Commands;

public class LoginCommand : IRequest<AuthDto>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}