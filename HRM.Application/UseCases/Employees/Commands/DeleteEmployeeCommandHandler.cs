using HRM.Domain.Exceptions;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Employees.Commands;

public class DeleteEmployeeCommandHandler(IUnitOfWork repository) : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.Employee.GetByIdAsync(request.Id, true);

        if (employee == null) throw new NotFoundException("Employee not found");

        if (employee.DeletedAt != null) throw new BadRequestException("Employee is already inactive");

        employee.DeletedAt = DateTime.UtcNow;

        repository.Employee.Update(employee);

        await repository.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}