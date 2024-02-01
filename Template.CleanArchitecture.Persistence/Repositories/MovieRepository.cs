using Microsoft.EntityFrameworkCore;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesPagination;
using Template.CleanArchitecture.Domain.Entities;
using Template.CleanArchitecture.Persistence.Data;

namespace Template.CleanArchitecture.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Movie>> GetPaginationList(MoviesPaginationDto moviesPaginationVm)
        {
            var moviesPaginationListVm = await _dbContext.Movie
                .Skip((moviesPaginationVm.PageNumber - 1) * moviesPaginationVm.PageSize)
                .Take(moviesPaginationVm.PageSize).ToListAsync();

            return moviesPaginationListVm;
        }
    }
}
