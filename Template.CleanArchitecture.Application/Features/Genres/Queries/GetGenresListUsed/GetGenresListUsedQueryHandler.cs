using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenresList
{
    public class GetGenresListUsedQueryHandler : IRequestHandler<GetGenresListUsedQuery, List<GenreListUsedVm>>
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public GetGenresListUsedQueryHandler(IMapper mapper, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<List<GenreListUsedVm>> Handle(GetGenresListUsedQuery request, CancellationToken cancellationToken)
        {
            var allGenres = (await _genreRepository.GetGenreUsed()).ToList();
            //.GroupBy(g => g.Name)
            //.Select(s => new GenreListUsedVm { Name = s.Key, Count = s.Key.Count() }); 
            ;
            return _mapper.Map<List<GenreListUsedVm>>(allGenres);
        }
    }
}
