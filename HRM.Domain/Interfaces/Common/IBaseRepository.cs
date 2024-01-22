using HRM.Domain.Common;
using HRM.Domain.Enums;

namespace HRM.Domain.Interfaces.Common;

public interface IBaseRepository<T> where T : class, IBaseEntity
{
    Task<T?> GetByIdAsync(int id, bool withDeleted = false);
    Task<TM?> GetByIdAsyncMap<TM>(int id);
    Task<IEnumerable<T>> GetAllAsync(FilterParams<T> filter);
    Task<IEnumerable<TM>> GetAllAsyncMap<TM>(FilterParams<T> filter);
    Task Add(T entity);
    Task AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}