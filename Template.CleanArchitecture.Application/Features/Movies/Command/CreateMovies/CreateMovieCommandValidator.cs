using FluentValidation;
using FluentValidation.Internal;

namespace Template.CleanArchitecture.Application.Features.Movies.Command.CreateMovies
{
    public class CreateMovieCommandValidator:AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(r => r.Language)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(r => r.GenreId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEqual(0).WithMessage("{PropertyName} must not equal 0.");

            RuleFor(r => r.Name)
                .NotEqual(e => e.Description).WithMessage("{PropertyName} must not equal Description.");
        }

       
    }
}
