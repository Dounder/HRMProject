using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using HRM.Application.UseCases.Employees.Commands;
using HRM.Application.UseCases.Employees.Queries;
using HRM.Domain.Common;
using IMS.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Employees;

[Route("api/employee"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Manager")]
public class EmployeeController(IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] PaginationParams pagination)
    {
        // Get roles from the token
        var roles = User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();
        
        // Check if the user is admin
        var isAdmin = roles.Contains("Admin");
        
        return Ok(await mediator.Send(new GetEmployeesQuery(pagination, isAdmin)));
    }

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
        return Ok(new { message = "Employee created successfully", data = result });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, UpdateEmployeeCommand command)
    {
        if (id != command.Id) return BadRequest("Id's do not match");

        await mediator.Send(command);
        return Ok(new { message = "Employee updated successfully" });
    }

    [HttpPut("{id:int}/restore"), Authorize(Roles = "Admin")]
    public async Task<ActionResult> Restore(int id)
    {
        await mediator.Send(new RestoreEmployeeCommand(id));
        return Ok(new { message = "Employee restored" });
    }

    [HttpDelete("{id:int}"), Authorize(Roles = "Admin")]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteEmployeeCommand(id));
        return Ok(new { message = "Employee deleted successfully" });
    }
}