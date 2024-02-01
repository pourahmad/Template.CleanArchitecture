using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenresList
{
    public class GetGenresListQueryHandler : IRequestHandler<GetGenresListQuery, List<GenreListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Genre> _genreRepository;

        public GetGenresListQueryHandler(IMapper mapper, IAsyncRepository<Genre> genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<List<GenreListVm>> Handle(GetGenresListQuery request, CancellationToken cancellationToken)
        {
            var allGenres = (await _genreRepository.ListAllAsync()).OrderBy(o => o.Id);            
            return _mapper.Map<List<GenreListVm>>(allGenres);
        }
    }
}
