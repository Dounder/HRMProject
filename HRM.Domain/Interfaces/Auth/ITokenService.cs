using HRM.Domain.Entities.Users;

namespace HRM.Domain.Interfaces.Auth;

public interface ITokenService
{
    Task<string> GenerateAccessToken(User user);
    Task<string> GenerateRefreshToken(User user);
    Task<string> RenewAccessToken(string username, string refreshToken);
}