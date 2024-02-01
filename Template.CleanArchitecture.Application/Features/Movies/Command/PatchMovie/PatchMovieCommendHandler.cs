using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Application.Exceptions;

namespace Template.CleanArchitecture.Application.Features.Movies.Command.PatchMovie
{
    public class PatchMovieCommendHandler : IRequestHandler<PatchMovieCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public PatchMovieCommendHandler(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task Handle(PatchMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);
            if (movie == null)
                throw new NotFoundException("Movie", request.Id);

            var movieToPatch = _mapper.Map<PatchMovieDto>(movie);
            request.PatchMovie.ApplyTo(movieToPatch);
            _mapper.Map(movieToPatch, movie);
            await _movieRepository.UpdateAsync(movie);
        }
    } 
}
