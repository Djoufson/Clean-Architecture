using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Commands;

public class CreateMovieCommand : IRequest<MovieResponse>
{
    public string Name { get; set; } = default!;
    public string Director { get; set; } = default!;
    public int ReleasedYear { get; set; }
}
