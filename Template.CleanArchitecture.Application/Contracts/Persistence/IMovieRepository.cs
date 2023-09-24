using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Contracts.Persistence
{
    public interface IMovieRepository:IAsyncRepository<Movie>
    {
    }
}
