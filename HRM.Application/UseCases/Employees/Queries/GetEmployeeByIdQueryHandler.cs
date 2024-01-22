using HRM.Application.UseCases.Employees.DTOs;
using HRM.Domain.Exceptions;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Employees.Queries;

public class GetEmployeeByIdQueryHandler(IUnitOfWork repository) : IRequestHandler<GetEmployeeByIdQuery, EmployeeDetailDto>
{
    public async Task<EmployeeDetailDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await repository.Employee.GetByIdAsyncMap<EmployeeDetailDto>(request.Id);

        if (employee == null) throw new NotFoundException("Employee not found");

        if (employee.DeletedAt != null) throw new NotFoundException("Employee inactive, please contact the administrator");

        return employee;
    }
}