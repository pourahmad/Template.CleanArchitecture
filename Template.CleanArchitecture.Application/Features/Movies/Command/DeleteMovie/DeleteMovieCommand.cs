using MediatR;

namespace Template.CleanArchitecture.Application.Features.Movies.Command.DeleteMovie
{
    public class DeleteMovieCommand:IRequest
    {
        public int Id { get; set; }
    }
}
