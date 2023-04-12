using MediatR;
using Movies.Core.Entities;

namespace Movies.Application.Queries;

public class GetAllMoviesQuery : IRequest<IEnumerable<Movie>>
{
}
