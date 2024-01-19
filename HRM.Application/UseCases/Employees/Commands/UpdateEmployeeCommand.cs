using HRM.Application.UseCases.Employees.DTOs;
using MediatR;

namespace HRM.Application.UseCases.Employees.Commands;

public class UpdateEmployeeCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public double? Salary { get; set; }

    public DateTime? DateHired { get; set; }
    public double? ExtraHourRate { get; set; }

    public int? DepartmentId { get; set; }
    public int? PositionId { get; set; }
}