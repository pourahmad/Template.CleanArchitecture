using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Template.CleanArchitecture.Application.Features.Movies.Queries.GetDetailsMovie;

namespace Template.CleanArchitecture.Application.Features.Movies.Command.PatchMovie
{
    public class PatchMovieCommand:IRequest
    {
        public int Id { get; set; }
        public JsonPatchDocument<PatchMovieDto> PatchMovie { get; set; }
    }
}
