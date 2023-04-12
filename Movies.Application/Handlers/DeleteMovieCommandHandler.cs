using MediatR;
using Movies.Application.Commands;
using Movies.Application.Mappers;
using Movies.Application.Responses;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, MovieResponse>
{
    private readonly IMoviesRepository _repository;

    public DeleteMovieCommandHandler(IMoviesRepository repository)
    {
        _repository = repository;
    }
    public async Task<MovieResponse> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _repository.DeleteAsync(request.Id);
        return MovieMapper.Mapper.Map<MovieResponse>(movie);
    }
}
