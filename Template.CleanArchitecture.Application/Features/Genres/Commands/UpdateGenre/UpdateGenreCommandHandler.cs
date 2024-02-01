using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Genre> _genreRepository;

        public UpdateGenreCommandHandler(IMapper mapper, IAsyncRepository<Genre> genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetByIdAsync(request.Id);

            if (genre == null)
                throw new Exception("Genre is not found!");

            _mapper.Map(request, genre, typeof(UpdateGenreCommand), typeof(Genre));
            await _genreRepository.UpdateAsync(genre);
        }
    }
}
