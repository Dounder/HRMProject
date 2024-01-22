using HRM.Application.UseCases.Employees.DTOs;
using MediatR;

namespace HRM.Application.UseCases.Employees.Queries;

public class GetEmployeeByIdQuery(int id) : IRequest<EmployeeDetailDto>
{
    public int Id { get; set; } = id;
}