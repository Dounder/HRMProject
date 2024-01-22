using MediatR;

namespace HRM.Application.UseCases.Trackings.Commands;

public class UpdateTrackCommand : IRequest<Unit>
{
    public int EmployeeId { get; set; }
    public TimeSpan? TimeOut { get; set; }
    public TimeSpan? LunchOut { get; set; }
    public TimeSpan? LunchIn { get; set; }
}