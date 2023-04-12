using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Commands;

public class UpdateMovieCommand : IRequest<MovieResponse>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Director { get; set; } = default!;
    public int ReleasedYear { get; set; }
}
