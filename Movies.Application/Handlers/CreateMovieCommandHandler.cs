using MediatR;
using Movies.Application.Commands;
using Movies.Application.Mappers;
using Movies.Application.Responses;
using Movies.Core.Entities;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieResponse>
{
    private readonly IMoviesRepository _repository;

    public CreateMovieCommandHandler(IMoviesRepository repository)
    {
        _repository = repository;
    }
    public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movieEntity = MovieMapper.Mapper.Map<Movie>(request);
        if (movieEntity is null)
            throw new ApplicationException("There is an issue with mapping ...");
        var newMovie = await _repository.AddAsync(movieEntity);
        var movieResponse = MovieMapper.Mapper.Map<MovieResponse>(newMovie);
        return movieResponse;
    }
}
