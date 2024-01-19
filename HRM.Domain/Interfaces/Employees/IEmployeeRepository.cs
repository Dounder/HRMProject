using HRM.Domain.Entities.Employees;
using HRM.Domain.Interfaces.Common;

namespace HRM.Domain.Interfaces.Employees;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
}