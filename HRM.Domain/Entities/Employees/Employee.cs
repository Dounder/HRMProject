namespace HRM.Domain.Entities.Employees;

public class Employee : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime DateHired { get; set; } = DateTime.UtcNow;
    public double Salary { get; set; }
    public double ExtraHourRate { get; set; } = 20;

    public Department Department { get; set; } = null!;
    public int DepartmentId { get; set; }
    public Position Position { get; set; } = null!;
    public int PositionId { get; set; }
    public HashSet<TimeTracking> TimeTrackings { get; set; } = null!;
}