using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.CleanArchitecture.Application.Features.Movies.Command.CreateMovies;
using Template.CleanArchitecture.Application.Features.Movies.Command.DeleteMovie;
using Template.CleanArchitecture.Application.Features.Movies.Command.UpdateMovie;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetDetailsMovie;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesList;

namespace Template.CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MoviesListVm>>> Get()
        {
            var movies =await _mediator.Send(new GetMoviesListQuery());
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<MoviesListVm>>> Get([FromRoute] int id)
        {
            var movie = await _mediator.Send(new GetMovieQuery() { Id = id});
            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post([FromBody] CreateMovieCommand createMovieCommand)
        {
            var restult = await _mediator.Send(createMovieCommand);
            return CreatedAtRoute(nameof(Get), new {id= restult.Movie.Id});
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromBody] UpdateMovieCommand updateMovieCommand)
        {
            await _mediator.Send(updateMovieCommand);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromBody] DeleteMovieCommand deleteMovieCommand)
        {
            await _mediator.Send(deleteMovieCommand);
            return Ok();
        }
    }
}
