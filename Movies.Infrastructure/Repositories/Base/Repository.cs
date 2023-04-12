using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities.Base;
using Movies.Core.Repositories.Base;

namespace Movies.Infrastructure.Repositories.Base;

public abstract class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _context.Remove(entity);
        var records = await _context.SaveChangesAsync();
        return records > 0;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public Task<T> GetByIdAsync(int id)
    {
        return _context.Set<T>().FirstAsync(m => m.Id == id);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        var records = await _context.SaveChangesAsync();
        return records > 0;
    }
}
