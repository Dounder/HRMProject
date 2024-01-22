using MediatR;

namespace HRM.Application.UseCases.Trackings.Commands;

public class CreateTrackingCommand : IRequest<Unit>
{
    public int EmployeeId { get; set; }
    public TimeSpan TimeIn { get; set; }
}