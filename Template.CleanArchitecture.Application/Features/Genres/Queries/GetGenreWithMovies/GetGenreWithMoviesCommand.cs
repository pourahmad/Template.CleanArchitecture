using MediatR;

namespace Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenreWithMovies
{
    public class GetGenreWithMoviesCommand:IRequest<GenreWithMovies>
    {
        public int Id { get; set; }
    }
}
