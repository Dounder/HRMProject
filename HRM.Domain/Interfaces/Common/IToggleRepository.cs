using HRM.Domain.Enums;

namespace HRM.Domain.Interfaces.Common;

public interface IToggleRepository
{
    public Task<StatusType> ToggleAsync<T>(int id, CancellationToken cancellationToken = default) where T : class, IBaseEntity;
}