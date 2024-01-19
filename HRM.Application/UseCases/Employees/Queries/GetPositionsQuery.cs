using HRM.Application.UseCases.Employees.DTOs;
using MediatR;

namespace HRM.Application.UseCases.Employees.Queries;

public class GetPositionsQuery(int departmentId) : IRequest<IEnumerable<PositionDto>>
{
    public int DepartmentId { get; set; } = departmentId;
}