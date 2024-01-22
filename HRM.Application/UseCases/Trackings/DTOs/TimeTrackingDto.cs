namespace HRM.Application.UseCases.Trackings.DTOs;

public class TimeTrackingDto
{
    public TimeSpan TimeIn { get; set; }
    public TimeSpan? TimeOut { get; set; }
    public TimeSpan? LunchOut { get; set; }
    public TimeSpan? LunchIn { get; set; }
    public double TotalHours { get; set; }
    public double TotalExtraHours { get; set; }
    public DateTime Date { get; set; }
}