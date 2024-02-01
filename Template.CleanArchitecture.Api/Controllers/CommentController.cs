using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.CleanArchitecture.Application.Features.Comment.Command.CreateComment;

namespace Template.CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateCommentCommand>> Post(CreateCommentCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.ValidationErrors?.Count()>0)
                return UnprocessableEntity(result.ValidationErrors);

            return Created("", result.Comment);
        }
    }
}
