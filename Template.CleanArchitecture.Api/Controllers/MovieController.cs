using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Template.CleanArchitecture.Application.Features.Movies.Command.CreateMovies;
using Template.CleanArchitecture.Application.Features.Movies.Command.DeleteMovie;
using Template.CleanArchitecture.Application.Features.Movies.Command.PatchMovie;
using Template.CleanArchitecture.Application.Features.Movies.Command.UpdateMovie;
using Template.CleanArchitecture .Application.Features.Movies.Queries.GetDetailsMovie;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesList;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesPagination;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetMovieWithComment;

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

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<List<MoviesListVm>>> Get()
        //{
        //    var movies =await _mediator.Send(new GetMoviesListQuery());
        //    return Ok(movies);
        //}

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<MoviesPaginationListVm>>> Get([FromQuery]MoviesPaginationDto moviesPaginationDto)
        {
            var movies = await _mediator.Send(new GetMoviesPaginationListQuery() { moviesPagination = moviesPaginationDto });
            return Ok(movies);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieVm>> Get([FromRoute] int id)
        {
            //var movie = await _mediator.Send(new GetMovieQuery() { Id = id});
            //return Ok(movie);
            var movieWithComment = await _mediator.Send(new GetMovieWithCommentQuery { Id = id });
            return Ok(movieWithComment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> Post([FromBody] CreateMovieCommand createMovieCommand)
        {
            var result = await _mediator.Send(createMovieCommand);
            if(result.ValidationErrors?.Count()> 0)
                return UnprocessableEntity(result.ValidationErrors);

            return CreatedAtAction(nameof(Get), new {id= result.Movie.Id}, result.Movie);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateMovieCommand updateMovieCommand)
        {
            await _mediator.Send(updateMovieCommand);
            return Ok();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Patch([FromRoute]int id, JsonPatchDocument<PatchMovieDto> patchDocument)
        {
            await _mediator.Send(new PatchMovieCommand() { Id = id, PatchMovie = patchDocument });
            return NoContent();
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

        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("allow-method", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
            return Ok();
        }
    }
}
