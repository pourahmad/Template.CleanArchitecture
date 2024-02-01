using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Movies.Command.UpdateMovie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public UpdateMovieCommandHandler(IMapper mapper, IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);

            if (movie == null)
                throw new Exception("Movie is not found!");

            _mapper.Map(request, movie, typeof(UpdateMovieCommand), typeof(Movie));
            await _movieRepository.UpdateAsync(movie);
        }
    }
}
