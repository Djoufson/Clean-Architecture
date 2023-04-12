using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using Movies.Infrastructure.Repositories.Base;

namespace Movies.Infrastructure.Repositories;

internal class MoviesRepository : Repository<Movie>, IMoviesRepository
{
    public MoviesRepository(DbContext context) : base(context)
    {
    }

    public Task<Movie> GetByNameAsync(string movieName)
    {
        return _context.Set<Movie>().FirstAsync(m => m.Name == movieName);
    }

    public Task<Movie[]> GetMoviesByDirectorNameAsync(string directorName)
    {
        return _context.Set<Movie>().Where(m => m.Director == directorName).ToArrayAsync();
    }
}
