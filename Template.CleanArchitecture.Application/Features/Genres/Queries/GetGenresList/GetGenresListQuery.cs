using MediatR;

namespace Template.CleanArchitecture.Application.Features.Genres.Queries.GetGenresList
{
    public class GetGenresListQuery:IRequest<List<GenreListVm>>
    {

    }
}
