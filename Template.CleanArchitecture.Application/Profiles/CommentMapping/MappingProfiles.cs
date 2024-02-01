using AutoMapper;
using Template.CleanArchitecture.Application.Features.Comment.Command.CreateComment;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetMovieWithComment;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Profiles.CommentMapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Comment, CreateCommentCommand>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Movie, MovieWithComment>().ReverseMap();
            CreateMap<Comment, GetMovieWithCommentQuery>().ReverseMap();


        }
    }
}
