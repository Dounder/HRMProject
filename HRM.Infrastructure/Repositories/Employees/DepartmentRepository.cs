using AutoMapper;
using HRM.Domain.Entities.Employees;
using HRM.Domain.Interfaces.Employees;
using HRM.Infrastructure.Data;
using HRM.Infrastructure.Repositories.Common;

namespace HRM.Infrastructure.Repositories.Employees;

public class DepartmentRepository(ApplicationDbContext context, IMapper mapper) : BaseRepository<Department>(context, mapper), IDepartmentRepository
{
}