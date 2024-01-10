using HRM.Domain.Interfaces;
using HRM.Domain.Interfaces.Auth;
using MediatR;

namespace HRM.Application.UseCases.Auth.Commands;

public class RenewTokenCommandHandler(ITokenService tokenService) : IRequestHandler<RenewTokenCommand, string>
{
    public async Task<string> Handle(RenewTokenCommand request, CancellationToken cancellationToken)
    {
        return await tokenService.RenewAccessToken(request.Username, request.RefreshToken);
    }
}