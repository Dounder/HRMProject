using HRM.Application.UseCases.Trackings.DTOs;
using MediatR;

namespace HRM.Application.UseCases.Trackings.Queries;

public class GetEmployeeTracksCommand(int id) : IRequest<IEnumerable<TimeTrackingDto>>
{
    public int Id { get; set; } = id;
}