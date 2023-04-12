using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers;

public class GetMoviesByIdQueryHandler : IRequestHandler<GetMoviesByIdQuery, MovieResponse>
{
    private readonly IMoviesRepository _repository;

    public GetMoviesByIdQueryHandler(IMoviesRepository repository)
    {
        _repository = repository;
    }
    public async Task<MovieResponse> Handle(GetMoviesByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await _repository.GetByIdAsync(request.Id);
        return MovieMapper.Mapper.Map<MovieResponse>(movie);
    }
}
