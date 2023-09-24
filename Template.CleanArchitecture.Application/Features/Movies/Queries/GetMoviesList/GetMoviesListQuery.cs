using MediatR;

namespace Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesList
{
    public class GetMoviesListQuery : IRequest<List<MoviesListVm>>
    {
    }
}
