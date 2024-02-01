using AutoMapper;
using Template.CleanArchitecture.Application.Features.Genres.Commands.CreateGenre;
using Template.CleanArchitecture.Application.Features.Genres.Commands.UpdateGenre;
using Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenresList;
using Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenreWithMovies;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Profiles.GenreMapping
{
    public partial class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Genre, GenreListVm>().ReverseMap();
            CreateMap<Genre, CreateGenreCommend>().ReverseMap();
            CreateMap<Genre, CreateGenreDto>();
            CreateMap<Genre, UpdateGenreCommand>().ReverseMap();
            CreateMap<Genre, GenreWithMovies>().ReverseMap();
            CreateMap<Movie, MoviesInGenreDto>().ReverseMap();
        }
    }
}
