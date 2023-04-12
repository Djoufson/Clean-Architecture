using MediatR;
using Movies.Application.Commands;
using Movies.Application.Mappers;
using Movies.Application.Responses;
using Movies.Core.Entities;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieResponse>
{
    private readonly IMoviesRepository _repository;

    public UpdateMovieCommandHandler(IMoviesRepository repository)
    {
        _repository = repository;
    }
    public async Task<MovieResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = MovieMapper.Mapper.Map<Movie>(request);
        await _repository.UpdateAsync(movie);
        return MovieMapper.Mapper.Map<MovieResponse>(movie);
    }
}
