using HRM.Application.Common.DTOs;

namespace HRM.Application.UseCases.Employees.DTOs;

public class EmployeeDto : BaseDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public double Salary { get; set; }
}

public class EmployeeDetailDto : EmployeeDto
{
    public DateTime DateHired { get; set; }
    public double ExtraHourRate { get; set; }

    public DepartmentDto Department { get; set; } = default!;
    public PositionDto Position { get; set; } = default!;
}

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}

public class PositionDto : DepartmentDto
{
}