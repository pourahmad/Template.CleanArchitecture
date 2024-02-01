using Template.CleanArchitecture.Application.Responses;

namespace Template.CleanArchitecture.Application.Features.Comment.Command.CreateComment
{
    public class CreateCommentCommandResponse:BaseResponse
    {
        public CreateCommentCommandResponse() : base() { }

        public CreateCommentDto Comment { get; set; } = default!;
    }
}
