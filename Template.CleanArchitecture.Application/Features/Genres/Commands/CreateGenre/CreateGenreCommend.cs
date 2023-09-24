using MediatR;

namespace Template.CleanArchitecture.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommend:IRequest<CreateGenreCommendResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
