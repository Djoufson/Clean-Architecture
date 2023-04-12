using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieResponse>>
{
    private readonly IMoviesRepository _repository;

    public GetAllMoviesQueryHandler(IMoviesRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<MovieResponse>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        var moviesEntities = await _repository.GetAllAsync();
        return MovieMapper.Mapper.Map<IEnumerable<MovieResponse>>(moviesEntities);
    }
}
