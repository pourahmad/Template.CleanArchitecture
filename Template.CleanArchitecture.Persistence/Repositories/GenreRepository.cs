using Microsoft.EntityFrameworkCore;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenresList;
using Template.CleanArchitecture.Domain.Entities;
using Template.CleanArchitecture.Persistence.Data;

namespace Template.CleanArchitecture.Persistence.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext dbContext) :base(dbContext)
        {
        }

        public async Task<Genre> GetGenreWithMovies(int id)
        {
            var genres = await _dbContext.Genre.Where(w => w.Id == id).Include(x => x.Movies).FirstOrDefaultAsync();
            return genres;
        }

        public async Task<List<GenreListUsedVm>> GetGenreUsed()
        {
            var genres = await _dbContext.Genre.Join(_dbContext.Movie,
                genre => genre.Id,
                movie => movie.GenreId,
                (genre, movie) => new GenreListUsedVm() {
                    Name = genre.Name,
                    Count = movie.GenreId
                }).GroupBy(g => g.Name)
                .Select(s => new GenreListUsedVm()
                {
                    Name = $"{s.Key} ({s.Count()})" ,
                    Count = s.Count()
                })
                .ToListAsync();
            return genres;
        }
    }
}
