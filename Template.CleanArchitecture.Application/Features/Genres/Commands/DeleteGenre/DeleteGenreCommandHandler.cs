using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Genre> _genreRepository;
        public DeleteGenreCommandHandler(IMapper mapper, IAsyncRepository<Genre> genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var Genre = await _genreRepository.GetByIdAsync(request.Id);
            if (Genre == null)
                throw new Exception("Genre is not found!");

            await _genreRepository.DeleteAsync(_mapper.Map<Genre>(Genre));
        }
    }
}
