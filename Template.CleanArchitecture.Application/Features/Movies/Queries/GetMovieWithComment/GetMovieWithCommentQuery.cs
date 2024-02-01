using MediatR;

namespace Template.CleanArchitecture.Application.Features.Movies.Queries.GetMovieWithComment
{
    public class GetMovieWithCommentQuery:IRequest<MovieWithComment>
    {
        public int Id { get; set; }
    }
}
