using HRM.Application.Common.DTOs;

namespace HRM.Application.UseCases.Employees.DTOs;

public class EmployeeDto : BaseDto
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public double Salary { get; set; }
    public DateTime DateHired { get; set; }
    public double ExtraHourRate { get; set; }

    public DepartmentDto Department { get; set; } = default!;
    public PositionDto Position { get; set; } = default!;
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

public class NewEmployeeDto
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;
    public EmployeeUserDto User { get; set; } = default!;
}

public class EmployeeUserDto
{
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}