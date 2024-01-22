using HRM.Domain.Enums;
using MediatR;

namespace HRM.Application.UseCases.Employees.Commands;

public class RestoreEmployeeCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}