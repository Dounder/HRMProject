using HRM.Domain.Enums;
using HRM.Domain.Interfaces.Common;
using HRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Repositories.Common;

public class ToggleRepository(ApplicationDbContext context) : IToggleRepository
{
    public async Task<StatusType> ToggleAsync<T>(int id, CancellationToken cancellationToken = default) where T : class, IBaseEntity
    {
        var entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

        if (entity is null) return StatusType.NotFound;

        entity.DeletedAt = entity.DeletedAt is null ? DateTime.UtcNow : null;

        return entity.DeletedAt is null ? StatusType.Restored : StatusType.Deactivated;
    }
}