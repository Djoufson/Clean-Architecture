using AutoMapper;
using Movies.Application.Commands;
using Movies.Application.Responses;
using Movies.Core.Entities;

namespace Movies.Application.Mappers;

internal class MovieMappingProfile : Profile
{
	public MovieMappingProfile()
	{
        // Source => Target 
        CreateMap<Movie, MovieResponse>().ReverseMap();
        CreateMap<Movie, CreateMovieCommand>().ReverseMap();
    }
}
