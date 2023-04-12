using MediatR;
using Movies.Application.Responses;
using Movies.Core.Entities;

namespace Movies.Application.Commands;

public class DeleteMovieCommand : IRequest<MovieResponse>
{
    public int Id { get; set; }

	public DeleteMovieCommand(int id)
	{
		Id = id;
	}
}
