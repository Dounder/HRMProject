using HRM.Application.UseCases.Employees.DTOs;
using HRM.Domain.Common;
using HRM.Domain.Entities.Employees;
using HRM.Domain.Interfaces.Common;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace HRM.Application.UseCases.Employees.Queries;

public class GetDepartmentsQueryHandler(IUnitOfWork repository, IMemoryCache cache) : IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentDto>>
{
    public async Task<IEnumerable<DepartmentDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        const string cacheKey = $"departments";

        if (cache.TryGetValue(cacheKey, out IEnumerable<DepartmentDto>? cachedDepartments))
            return cachedDepartments ?? Enumerable.Empty<DepartmentDto>();

        var filter = new FilterParams<Department> { Pagination = new PaginationParams { Limit = 10000, Offset = 0 }, OrderByDescending = false };
        var departments = await repository.Department.GetAllAsyncMap<DepartmentDto>(filter);

        // Set cache options.
        var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(7));
        var departmentsList = departments.ToList();
        cache.Set(cacheKey, departmentsList, cacheEntryOptions);

        return departmentsList;
    }
}