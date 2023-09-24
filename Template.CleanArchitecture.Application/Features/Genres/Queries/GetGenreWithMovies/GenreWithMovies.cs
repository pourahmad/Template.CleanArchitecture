namespace Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenreWithMovies
{
    public class GenreWithMovies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MoviesInGenreDto> movies { get; set; } = new List<MoviesInGenreDto>();
    }
}
