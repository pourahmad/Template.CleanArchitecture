using Template.CleanArchitecture.Application.Responses;

namespace Template.CleanArchitecture.Application.Features.Movies.Command.CreateMovies
{
    public class CreateMovieCommandResponse:BaseResponse
    {
        public CreateMovieCommandResponse():base()
        {
            
        }

        public CreateMovieDto Movie { get; set; } = default!;
    }
}
