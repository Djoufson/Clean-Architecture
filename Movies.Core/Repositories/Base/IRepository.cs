using Movies.Core.Entities.Base;

namespace Movies.Core.Repositories.Base;

public interface IRepository<T> where T : Entity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<bool> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
}
