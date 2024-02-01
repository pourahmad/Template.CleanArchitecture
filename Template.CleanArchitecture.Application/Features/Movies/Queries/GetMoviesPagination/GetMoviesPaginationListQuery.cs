using MediatR;

namespace Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesPagination
{
    public class GetMoviesPaginationListQuery: IRequest<List<MoviesPaginationListVm>>
    {
        public MoviesPaginationDto moviesPagination { get; set; }
    }
}
