using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Queries;

public class GetMoviesByIdQuery : IRequest<MovieResponse>
{
    public int Id { get; set; }
    public GetMoviesByIdQuery(int id)
    {
        Id = id;
    }
}
