using FluentValidation;

namespace Template.CleanArchitecture.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommendValidator:AbstractValidator<CreateGenreCommend>
    {
        public CreateGenreCommendValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
