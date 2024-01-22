using AutoMapper;
using HRM.Domain.Exceptions;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Employees.Commands;

public class UpdateEmployeeCommandHandler(IUnitOfWork repository, IMapper mapper) : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.Employee.GetByIdAsync(request.Id);

        if (employee == null) throw new NotFoundException("Employee not found");

        if (employee.DeletedAt != null) throw new NotFoundException("Employee is inactive, please contact the administrator");

        employee = mapper.Map(request, employee);

        repository.Employee.Update(employee);

        await repository.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}