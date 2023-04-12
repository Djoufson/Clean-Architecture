using AutoMapper;

namespace Movies.Application.Mappers;

internal class MovieMapper : Profile
{
    private static Lazy<IMapper> Lazzy = new (() => 
    {
        var config = new MapperConfiguration((cfg) => 
        {
            cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<MovieMappingProfile>();
        });

        return config.CreateMapper();
    });

    public static IMapper Mapper => Lazzy.Value;
}
