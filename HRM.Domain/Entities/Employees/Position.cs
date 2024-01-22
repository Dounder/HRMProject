namespace HRM.Domain.Entities.Employees;

public class Position : BaseEntity
{
    public string Name { get; set; } = null!;
    public Department Department { get; set; } = null!;
    public int DepartmentId { get; set; }
    public HashSet<Employee> Employees { get; set; } = null!;
}