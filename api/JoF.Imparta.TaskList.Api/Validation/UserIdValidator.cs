namespace JoF.Imparta.TaskList.Api.Validation;

using FluentValidation;

public class UserIdValidator : AbstractValidator<Guid>
{
    public UserIdValidator()
    {
        RuleFor(id => id)
            .NotNull()
            .NotEmpty()
            .WithMessage("UserId must be a valid Guid and cannot be null or empty.");
    }
}