using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieResponse>>> GetAllMovies()
    {
        var query = new GetAllMoviesQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id:int}", Name = nameof(GetMoviesByDirectorName))]
    public async Task<ActionResult<IEnumerable<MovieResponse>>> GetMoviesByDirectorName(int id)
    {
        var query = new GetMoviesByIdQuery(id);
        try
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception)
        {
            return BadRequest("L'element recherche n'existe pas");
        }
    }

    [HttpGet("{directorName}")]
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
		return CreatedAtAction(nameof(GetMoviesByDirectorName), new { Id = response.Id }, response);
	}

    [HttpPut]
    public async Task<ActionResult<MovieResponse>> UpdateMovie(UpdateMovieCommand movieCommand)
    {
        var response = await _mediator.Send(movieCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<MovieResponse>> DelateMovie(int id)
    {
        var movieCommand = new DeleteMovieCommand(id);
        var response = await _mediator.Send(movieCommand);
        return Ok(response);
    }
}
