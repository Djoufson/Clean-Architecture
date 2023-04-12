using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;

namespace Movies.Infrastructure.Data;

public class MoviesContext : DbContext
{
	public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
	{

	}

	public DbSet<Movie> Movies { get; set; } = default!;
}
