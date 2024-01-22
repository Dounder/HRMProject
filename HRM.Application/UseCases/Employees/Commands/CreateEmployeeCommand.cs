using MediatR;

namespace HRM.Application.UseCases.Employees.Commands;

public class CreateEmployeeCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public double Salary { get; set; }

    public DateTime? DateHired { get; set; } = DateTime.UtcNow;
    public double? ExtraHourRate { get; set; } = 20;

    public int DepartmentId { get; set; }
    public int PositionId { get; set; }
}