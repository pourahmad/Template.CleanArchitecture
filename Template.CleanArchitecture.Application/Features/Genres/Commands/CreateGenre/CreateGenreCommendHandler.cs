using AutoMapper;
using MediatR;
using Template.CleanArchitecture.Application.Contracts.Persistence;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommendHandler : IRequestHandler<CreateGenreCommend, CreateGenreCommendResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Genre> _GenreRepository;

        public CreateGenreCommendHandler(IMapper mapper, IAsyncRepository<Genre> GenreRepository)
        {
            _mapper = mapper;
            _GenreRepository = GenreRepository;
        }

        public async Task<CreateGenreCommendResponse> Handle(CreateGenreCommend request, CancellationToken cancellationToken)
        {
            var createGenreCommendResponse = new CreateGenreCommendResponse();

            var validator = new CreateGenreCommendValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
            {
                createGenreCommendResponse.Success = false;
                createGenreCommendResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createGenreCommendResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            else if (createGenreCommendResponse.Success)
            {
                Genre genre = _mapper.Map<Genre>(request);
                genre = await _GenreRepository.AddAsync(genre);

                createGenreCommendResponse.Genre = _mapper.Map<CreateGenreDto>(genre);
            }

            return createGenreCommendResponse;
        }
    }
}
 