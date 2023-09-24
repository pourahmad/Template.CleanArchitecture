using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<GenreListVm>>> Get([FromRoute] int id)
        {
            var genreWhithMovie = await _mediator.Send(new GetGenreWithMoviesCommand() { Id = id });
            if (genreWhithMovie == null)
                return NotFound();

            return Ok(genreWhithMovie);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateGenreCommend createGenreCommend)
        {
            var restult = await _mediator.Send(createGenreCommend);
            return CreatedAtAction($"{nameof(Get)}/{restult.Genre.Id}", null);
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
    }
}
