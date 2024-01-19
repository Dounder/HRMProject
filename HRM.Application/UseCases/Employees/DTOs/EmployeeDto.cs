using HRM.Application.Common.DTOs;

namespace HRM.Application.UseCases.Employees.DTOs;

public class EmployeeDto : BaseDto
{
}

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}

public class PositionDto : DepartmentDto
{
}