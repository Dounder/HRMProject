using HRM.Domain.Entities.Employees;

namespace HRM.Domain.Entities.Trackings;

public class TimeTracking : BaseEntity
{
    public Employee Employee { get; set; } = null!;
    public int EmployeeId { get; set; }
    public TimeSpan TimeIn { get; set; }
    public TimeSpan? TimeOut { get; set; }
    public TimeSpan? LunchOut { get; set; }
    public TimeSpan? LunchIn { get; set; }
    public double TotalHours { get; set; }
    public double TotalExtraHours { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}