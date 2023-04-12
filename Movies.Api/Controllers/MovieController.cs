using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands;
using Movies.Application.Handlers;
using Movies.Application.Queries;
using Movies.Application.Responses;

namespace Movies.Api.Controllers;

public class MovieController : ApiController
{
	private readonly IMediator _mediator;

	public MovieController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet("/{directorName}")]
	public async Task<ActionResult<IEnumerable<MovieResponse>>> GetMoviesByDirectorName(string directorName)
	{
		var query = new GetMoviesByDirectorNameQuery(directorName);
		var response = await _mediator.Send(query);
		return Ok(response);
	}

	[HttpPost]
    public async Task<ActionResult<MovieResponse>> CreateMovie(CreateMovieCommand movieCommand)
	{
		var response = await _mediator.Send(movieCommand);
		return Ok(response);
	}
}
