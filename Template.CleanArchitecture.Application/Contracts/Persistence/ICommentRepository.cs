using Template.CleanArchitecture.Application.Responses;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Contracts.Persistence
{
    public interface ICommentRepository : IAsyncRepository<Comment>
    {
        BaseResponse PublishComment(int commentId);
    }
}
