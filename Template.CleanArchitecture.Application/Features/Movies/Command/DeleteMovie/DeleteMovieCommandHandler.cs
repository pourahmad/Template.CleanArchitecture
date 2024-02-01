using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Movies.Command.DeleteMovie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public DeleteMovieCommandHandler(IMapper mapper, IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);

            if (movie == null)
                throw new Exception("Movie is not found!");

            await _movieRepository.DeleteAsync(movie);
        }
    }
}
