using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Template.CleanArchitecture.Application.Features.Genres.Commands.CreateGenre;
using Template.CleanArchitecture.Application.Features.Genres.Commands.DeleteGenre;
using Template.CleanArchitecture.Application.Features.Genres.Commands.UpdateGenre;
using Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenresList;
using Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenreWithMovies;

namespace Template.CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<GenreListVm>>> Get()
        {
            var genres = await _mediator.Send(new GetGenresListQuery());
            if (genres.Count() == 0)
                return NotFound();

            return Ok(genres);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenreWithMovies>> Get([FromRoute] int id)
        {
            var genreWhithMovie = await _mediator.Send(new GetGenreWithMoviesQuery() { Id = id });
            if (genreWhithMovie == null)
                return NotFound();

            return Ok(genreWhithMovie);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateGenreCommend createGenreCommend)
        {
            var result = await _mediator.Send(createGenreCommend);
            if (result.ValidationErrors?.Count() > 0)
                return UnprocessableEntity(result.ValidationErrors);

            return CreatedAtAction(nameof(Get), new {id= result.Genre.Id}, result.Genre);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put([FromBody] UpdateGenreCommand updateGenreCommand)
        {
            await _mediator.Send(updateGenreCommand);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromBody] DeleteGenreCommand deleteGenreCommand)
        {
            await _mediator.Send(deleteGenreCommand);
            return Ok();
        }

        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("allow-method", "GET, POST, PUT, DELETE, OPTIONS");
            return Ok();
        }
    }
}
 