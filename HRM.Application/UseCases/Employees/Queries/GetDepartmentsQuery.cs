using HRM.Application.UseCases.Employees.DTOs;
using MediatR;

namespace HRM.Application.UseCases.Employees.Queries;

public class GetDepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
{
}