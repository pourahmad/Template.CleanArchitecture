using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Application.Exceptions;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenreWithMovies
{
    public class GetGenreWithMoviesCommandHandler : IRequestHandler<GetGenreWithMoviesCommand, GenreWithMovies>
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public GetGenreWithMoviesCommandHandler(IMapper mapper, IGenreRepository genreRepository, IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<GenreWithMovies> Handle(GetGenreWithMoviesCommand request, CancellationToken cancellationToken)
        {
            var genreWithMovies = await _genreRepository.GetGenreWithMovies(request.Id);
            //if (genreWithMovies == null)
            //    throw new NotFoundException(nameof(Genre),request.Id);

            return _mapper.Map<GenreWithMovies>(genreWithMovies);
        }
    }
}