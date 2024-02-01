using Template.CleanArchitecture.Application.Responses;

namespace Template.CleanArchitecture.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommendResponse:BaseResponse
    {
        public CreateGenreCommendResponse():base()
        {            
        }

        public CreateGenreDto Genre { get; set; } = default!;
    }
}
