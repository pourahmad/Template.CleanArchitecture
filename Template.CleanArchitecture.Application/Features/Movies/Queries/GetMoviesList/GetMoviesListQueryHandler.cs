using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesList
{
    public class GetMoviesListQueryHandler : IRequestHandler<GetMoviesListQuery, List<MoviesListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movie> _movieRepository;

        public GetMoviesListQueryHandler(IMapper mapper, IAsyncRepository<Movie> movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<List<MoviesListVm>> Handle(GetMoviesListQuery request, CancellationToken cancellationToken)
        {
            var movies = (await _movieRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();

            return _mapper.Map<List<MoviesListVm>>(movies);
        }
    }
}
