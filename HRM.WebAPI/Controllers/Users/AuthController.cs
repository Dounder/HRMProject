using HRM.Application.UseCases.Auth.Commands;
using HRM.Application.UseCases.Auth.DTOs;
using IMS.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Users;

[Route("api/auth")]
public class AuthController(IMediator mediator) : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPost("renew_access_token")]
    public async Task<IActionResult> RenewToken(RenewTokenDto dto)
    {
        var command = new RenewTokenCommand(dto.Username, dto.RefreshToken);

        return Ok(new { accessToken = await mediator.Send(command) });
    }
}