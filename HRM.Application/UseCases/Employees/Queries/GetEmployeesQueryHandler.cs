using HRM.Application.UseCases.Employees.DTOs;
using HRM.Domain.Common;
using HRM.Domain.Entities.Employees;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Employees.Queries;

public class GetEmployeesQueryHandler(IUnitOfWork repository) : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
{
    public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var filter = new FilterParams<Employee>
        {
            Pagination = request.Pagination, Where = request.IsAdmin ? null : x => x.DeletedAt == null
        };
        var employees = await repository.Employee.GetAllAsyncMap<EmployeeDto>(filter);

        return employees;
    }
}