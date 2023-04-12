using Microsoft.EntityFrameworkCore;
using Movies.Application.Handlers;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using Movies.Core.Repositories.Base;
using Movies.Infrastructure.Data;
using Movies.Infrastructure.Repositories;
using Movies.Infrastructure.Repositories.Base;
using System.Reflection;

namespace Movies.Api;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<MoviesContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("SqlServerCon"), b => b.MigrationsAssembly("Movies.Api"));
        });

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient<IRepository<Movie>, MoviesRepository>();
        services.AddTransient<IMoviesRepository, MoviesRepository>();
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(CreateMovieCommandHandler).GetTypeInfo().Assembly));
    }
}
