using Movies.Core.Entities.Base;

namespace Movies.Core.Repositories.Base;

public interface IRepository<T> where T : Entity, new()
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> AddAsync(T entity);
    Task<T> GetAsync(int id);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
}
