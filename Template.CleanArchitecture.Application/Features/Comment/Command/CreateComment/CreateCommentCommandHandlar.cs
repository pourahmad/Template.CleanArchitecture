using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Domain.Entities;
using CommentEntiy = Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Comment.Command.CreateComment
{
    public class CreateCommentCommandHandlar : IRequestHandler<CreateCommentCommand, CreateCommentCommandResponse>
    {
        private readonly IAsyncRepository<CommentEntiy.Comment> _commentRepository;
        private readonly IAsyncRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandlar(IAsyncRepository<Domain.Entities.Comment> commentRepository, IAsyncRepository<Movie> movieRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            CreateCommentCommandResponse createCommentCommandResponse = new CreateCommentCommandResponse();

            var validator = new CreateCommentCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count() > 0)
            {
                createCommentCommandResponse.Success = false;
                createCommentCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validatorResult.Errors)
                {
                    createCommentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            else if (createCommentCommandResponse.Success)
            {
                var movie = await _movieRepository.GetByIdAsync(request.MovieId);
                if (movie == null)
                    createCommentCommandResponse.Success = false;

                var comment = _mapper.Map<Domain.Entities.Comment>(request);
                comment.Movie = movie;

                await _commentRepository.AddAsync(comment);

                createCommentCommandResponse.Comment = _mapper.Map<CreateCommentDto>(comment);
            }

            return createCommentCommandResponse;
        }
    }
}
