using MediatR;

namespace Template.CleanArchitecture.Application.Features.Movies.Queries.GetDetailsMovie
{
    public class GetMovieQuery: IRequest<MovieVm>
    {
        public int Id { get; set; }
    }
}
