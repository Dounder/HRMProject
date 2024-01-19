using System.ComponentModel.DataAnnotations;
using HRM.Application.UseCases.Common.Commands;
using HRM.Application.UseCases.Employees.Commands;
using HRM.Application.UseCases.Employees.Queries;
using HRM.Domain.Common;
using HRM.Domain.Entities.Employees;
using HRM.Domain.Enums;
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
    public async Task<ActionResult> Get([FromQuery] PaginationParams pagination) =>
        Ok(await mediator.Send(new GetEmployeesQuery(pagination)));

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetEmployeeByIdQuery(id));
        return Ok(result);
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
    public async Task<ActionResult> Post(CreateEmployeeCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(new { message = "Employee created successfully", id = result });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, UpdateEmployeeCommand command)
    {
        if (id != command.Id) return BadRequest("Id's do not match");

        await mediator.Send(command);
        return Ok(new { message = "Employee updated successfully" });
    }

    [HttpPut("toggle/{id:int}")]
    public async Task<ActionResult> Toggle(int id)
    {
        var result = await mediator.Send(new ToggleEntityCommand<Employee> { Id = id });

        return Ok(new
        {
            message = result == StatusType.Deactivated ? "Employee deactivated successfully" : "Employee activated successfully"
        });
    }
}