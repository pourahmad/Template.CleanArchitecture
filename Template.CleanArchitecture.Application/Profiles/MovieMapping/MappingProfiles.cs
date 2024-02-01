using AutoMapper;
using Template.CleanArchitecture.Application.Features.Movies.Command.CreateMovies;
using Template.CleanArchitecture.Application.Features.Movies.Command.PatchMovie;
using Template.CleanArchitecture.Application.Features.Movies.Command.UpdateMovie;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetDetailsMovie;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesList;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesPagination;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Profiles.MovieMapping
{
    public partial class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, CreateMovieCommand>().ReverseMap();
            CreateMap<Movie, CreateMovieDto>();
            CreateMap<Movie, UpdateMovieCommand>().ReverseMap();
            CreateMap<Movie, MoviesListVm>().ReverseMap();
            CreateMap<Movie, MovieVm>().ReverseMap();
            CreateMap<Movie, PatchMovieDto>().ReverseMap();
            CreateMap<Movie, MoviesPaginationListVm>().ReverseMap();
        }
    }
}
