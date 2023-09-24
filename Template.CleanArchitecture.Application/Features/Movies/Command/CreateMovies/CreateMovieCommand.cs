using MediatR;

namespace Template.CleanArchitecture.Application.Features.Movies.Command.CreateMovies
{
    public class CreateMovieCommand:IRequest<CreateMovieCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
    }
}
