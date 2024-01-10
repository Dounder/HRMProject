using MediatR;

namespace HRM.Application.UseCases.Auth.Commands;

public class RenewTokenCommand(string username, string refreshToken) : IRequest<string>
{
    public string RefreshToken { get; set; } = refreshToken;
    public string Username { get; set; } = username;
}