using Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesPagination;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Contracts.Persistence
{
    public interface IMovieRepository:IAsyncRepository<Movie>
    {
        Task<List<Movie>> GetPaginationList(MoviesPaginationDto moviesPaginationVm);
    }
}
