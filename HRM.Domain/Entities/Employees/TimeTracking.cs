namespace HRM.Domain.Entities.Employees;

public class TimeTracking : BaseEntity
{
    public Employee Employee { get; set; } = null!;
    public int EmployeeId { get; set; }
    public TimeSpan TimeIn { get; set; }
    public TimeSpan TimeOut { get; set; }
    public double TotalHours { get; set; }
    public double TotalExtraHours { get; set; }
}