using System.ComponentModel.DataAnnotations;
using HRM.Application.UseCases.Trackings.Commands;
using HRM.Application.UseCases.Trackings.Queries;
using IMS.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Trackings;

[Route("api/time_tracking"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TimeTrackingController(IMediator mediator) : BaseController
{
    [HttpGet, Authorize(Roles = "Admin, Manager")]
    public async Task<ActionResult> Get([FromQuery, Required] int employeeId) =>
        Ok(await mediator.Send(new GetEmployeeTracksCommand(employeeId)));

    [HttpPost, Authorize(Roles = "Employee")]
    public async Task<ActionResult> Post(CreateTrackingCommand command)
    {
        await mediator.Send(command);
        return Ok(new { message = "Time tracking created" });
    }

    [HttpPut, Authorize(Roles = "Employee")]
    public async Task<ActionResult> Put(UpdateTrackCommand command)
    {
        await mediator.Send(command);
        return Ok(new { message = "Time tracking updated" });
    }
}