using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Application.Responses;
using Template.CleanArchitecture.Domain.Entities;
using Template.CleanArchitecture.Persistence.Data;

namespace Template.CleanArchitecture.Persistence.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public BaseResponse PublishComment(int commentId)
        {
            throw new NotImplementedException();
        }
    }
}
