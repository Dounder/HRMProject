using System.ComponentModel.DataAnnotations;
using HRM.Application.UseCases.Employees.Queries;
using IMS.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Employees;

[Route("api/employee"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class EmployeeController(IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<ActionResult> Get() => Ok($"Get all");

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        return new OkObjectResult($"Get {id}");
    }

    [HttpGet("departments")]
    public async Task<ActionResult> GetDepartments()
    {
        var result = await mediator.Send(new GetDepartmentsQuery());
        return Ok(result);
    }

    [HttpGet("positions")]
    public async Task<ActionResult> GetPositions([FromQuery, Required] int departmentId)
    {
        if (departmentId <= 0) return BadRequest("DepartmentId is required");

        var result = await mediator.Send(new GetPositionsQuery(departmentId));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Post()
    {
        return new OkObjectResult($"Create");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id)
    {
        return new OkObjectResult($"Update {id}");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        return new OkObjectResult($"Delete {id}");
    }
}