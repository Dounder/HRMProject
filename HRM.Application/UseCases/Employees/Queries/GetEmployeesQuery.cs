using HRM.Application.UseCases.Employees.DTOs;
using HRM.Domain.Common;
using MediatR;

namespace HRM.Application.UseCases.Employees.Queries;

public class GetEmployeesQuery(PaginationParams pagination) : IRequest<IEnumerable<EmployeeDto>>
{
    public PaginationParams Pagination { get; set; } = pagination;
}