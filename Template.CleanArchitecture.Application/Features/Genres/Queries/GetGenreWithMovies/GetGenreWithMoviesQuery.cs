using MediatR;

namespace Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenreWithMovies
{
    public class GetGenreWithMoviesQuery:IRequest<GenreWithMovies>
    {
        public int Id { get; set; }
    }
}
