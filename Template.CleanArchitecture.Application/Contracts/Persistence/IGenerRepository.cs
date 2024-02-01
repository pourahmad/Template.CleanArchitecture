using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Contracts.Persistence
{
    public interface IGenreRepository:IAsyncRepository<Genre>
    {
        Task<Genre> GetGenreWithMovies(int id);
    }
}
