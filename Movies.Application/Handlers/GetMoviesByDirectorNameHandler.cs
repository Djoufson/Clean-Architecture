using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers;

public class GetMoviesByDirectorNameHandler : IRequestHandler<GetMoviesByDirectorNameQuery, IEnumerable<MovieResponse>>
{
    private readonly IMoviesRepository _repository;

    public GetMoviesByDirectorNameHandler(IMoviesRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<MovieResponse>> Handle(GetMoviesByDirectorNameQuery request, CancellationToken cancellationToken)
    {
        var responses = await _repository.GetMoviesByDirectorNameAsync(request.DirectorName);
        return MovieMapper.Mapper.Map<IEnumerable<MovieResponse>>(responses);
    }
}
