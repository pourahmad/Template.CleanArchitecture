using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;

namespace Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesPagination
{
    public class GetMoviesPaginationListQueryHadler : IRequestHandler<GetMoviesPaginationListQuery, List<MoviesPaginationListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public GetMoviesPaginationListQueryHadler(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<List<MoviesPaginationListVm>> Handle(GetMoviesPaginationListQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetPaginationList(request.moviesPagination);            
            return _mapper.Map<List<MoviesPaginationListVm>>(movies);
        }
    }
}
