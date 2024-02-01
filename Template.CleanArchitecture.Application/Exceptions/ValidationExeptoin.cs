using FluentValidation.Results;

namespace Template.CleanArchitecture.Application.Exceptions
{
    public class ValidationExeptoin : Exception
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationExeptoin(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
