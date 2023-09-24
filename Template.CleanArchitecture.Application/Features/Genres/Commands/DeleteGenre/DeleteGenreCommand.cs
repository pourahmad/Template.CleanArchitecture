using MediatR;

namespace Template.CleanArchitecture.Application.Features.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommand:IRequest
    {
        public int Id { get; set; }
    }
}
