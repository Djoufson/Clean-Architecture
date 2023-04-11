using Movies.Core.Entities;
using Movies.Core.Repositories.Base;

namespace Movies.Core.Repositories;

public interface IMoviesRepository : IRepository<Movie>
{
    Task<Movie> GetByNameAsync(string movieName);
    Task<IEnumerable<Movie>> GetMoviesByDirectorNameAsync(string directorName);
}
