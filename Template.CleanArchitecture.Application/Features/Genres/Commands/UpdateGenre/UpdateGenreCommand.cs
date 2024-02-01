using MediatR;

namespace Template.CleanArchitecture.Application.Features.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
