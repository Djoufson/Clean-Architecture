using Microsoft.Extensions.Logging;
using Movies.Core.Entities;

namespace Movies.Infrastructure.Data;

public class MoviesContextSeed
{
    public static async Task SeedDatas(MoviesContext context, ILogger logger)
    {
        logger.LogInformation("==> Seeding datas");
        try
        {
            // We ensure that the database is created or already exists
            await context.Database.EnsureCreatedAsync();

            if (context.Movies.Any())
                return;

            await context.Movies.AddRangeAsync(GetMockedMovies());
        }
        catch (Exception) { }
    }

    private static Movie[] GetMockedMovies()
    {
        return new Movie[] 
        {
            new (){ Name = "Black Panther", Director = "DG Ling", ReleasedYear = 2017 },
            new (){ Name = "Avatar", Director = "James Cameroon", ReleasedYear = 1997 },
            new (){ Name = "Titanic", Director = "James Cameroon", ReleasedYear = 2009 },
            new (){ Name = "Die Another Day", Director = "Lee Tamahori", ReleasedYear = 2002 },
        }; 
    }
}
