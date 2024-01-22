using HRM.Domain.Exceptions;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Employees.Commands;

public class RestoreEmployeeCommandHandler(IUnitOfWork repository) : IRequestHandler<RestoreEmployeeCommand, Unit>
{
    public async Task<Unit> Handle(RestoreEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.Employee.GetByIdAsync(request.Id, true);

        if (employee == null) throw new NotFoundException("Employee not found");

        if (employee.DeletedAt == null) throw new BadRequestException("Employee is already active");

        employee.DeletedAt = null;

        repository.Employee.Update(employee);

        await repository.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}