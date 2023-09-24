using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Movies.Command.CreateMovies
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public CreateMovieCommandHandler(IMapper mapper, IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var createMovieCommandResponse = new CreateMovieCommandResponse();

            var validator = new CreateMovieCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count() > 0)
            {
                createMovieCommandResponse.Success = false;
                createMovieCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validatorResult.Errors)
                {
                    createMovieCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            else if (createMovieCommandResponse.Success) 
            {
                var movie = _mapper.Map<Movie>(request);
                await _movieRepository.AddAsync(movie);

                createMovieCommandResponse.Movie = _mapper.Map<CreateMovieDto>(movie);
            }

            return createMovieCommandResponse;
        }
    }
}
