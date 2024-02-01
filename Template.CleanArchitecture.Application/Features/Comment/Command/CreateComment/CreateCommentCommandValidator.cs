using FluentValidation;

namespace Template.CleanArchitecture.Application.Features.Comment.Command.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(p => p.Title)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull()
             .Length(3,50).WithMessage("{PropertyName} must betewen 3, 50 character.");

            RuleFor(p => p.Text)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(10).WithMessage("{PropertyName} must not fewer 10 character")
                .Matches("^[a-zA-Z0-9 ]+$").WithMessage("{PropertyName} must use a-z, A-Z or 0-9");

            RuleFor(p => p.MovieId)
                .NotNull()
                .GreaterThan(1).WithMessage("{PropertyName} must greater then 1.");

        }
    }
}
