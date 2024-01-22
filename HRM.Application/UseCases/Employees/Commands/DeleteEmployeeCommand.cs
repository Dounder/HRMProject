using MediatR;

namespace HRM.Application.UseCases.Employees.Commands;

public class DeleteEmployeeCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}