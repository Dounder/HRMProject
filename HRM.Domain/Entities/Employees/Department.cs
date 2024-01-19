namespace HRM.Domain.Entities.Employees;

public class Department : BaseEntity
{
    public string Name { get; set; } = null!;
    public HashSet<Position> Positions { get; set; } = null!;
    public HashSet<Employee> Employees { get; set; } = null!;
}