using Microsoft.EntityFrameworkCore;
using Template.CleanArchitecture.Application.Contracts.Persistence;
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
    }
}
