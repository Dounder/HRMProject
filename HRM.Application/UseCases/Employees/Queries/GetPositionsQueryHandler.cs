using HRM.Application.UseCases.Employees.DTOs;
using HRM.Domain.Common;
using HRM.Domain.Entities.Employees;
using HRM.Domain.Interfaces.Common;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace HRM.Application.UseCases.Employees.Queries;

public class GetPositionsQueryHandler(IUnitOfWork repository, IMemoryCache cache) : IRequestHandler<GetPositionsQuery, IEnumerable<PositionDto>>
{
    public async Task<IEnumerable<PositionDto>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"positions:{request.DepartmentId}";

        if (cache.TryGetValue(cacheKey, out IEnumerable<PositionDto>? cachedPositions)) return cachedPositions ?? Enumerable.Empty<PositionDto>();

        var filter = new FilterParams<Position>
        {
            Pagination = new PaginationParams { Limit = 10000, Offset = 0 },
            Where = x => x.DeletedAt == null && x.DepartmentId == request.DepartmentId,
            OrderByDescending = false
        };
        var positions = await repository.Position.GetAllAsyncMap<PositionDto>(filter);

        var positionsList = positions.ToList();
        var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(7));
        cache.Set(cacheKey, positionsList, cacheEntryOptions);

        return positionsList;
    }
}