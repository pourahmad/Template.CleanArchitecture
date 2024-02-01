using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using CommentEntiy = Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Movies.Queries.GetMovieWithComment
{
    public class GetMovieWithCommentQueryHandlar : IRequestHandler<GetMovieWithCommentQuery, MovieWithComment>
    {
        private readonly IAsyncRepository<CommentEntiy.Comment> _commentRepository;
        private readonly IMapper _mapper;

        public GetMovieWithCommentQueryHandlar(IAsyncRepository<CommentEntiy.Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<MovieWithComment> Handle(GetMovieWithCommentQuery request, CancellationToken cancellationToken)
        {

            var comments = await _commentRepository.ListAllAsync();
            throw new NotImplementedException();
        }
    }
}
