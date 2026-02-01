namespace JoF.Imparta.TaskList.Api.Validation;

using FluentValidation;

public class UserIdValidator : AbstractValidator<Guid>
{
    public UserIdValidator()
    {
        RuleFor(id => id).SetValidator(new GuidValidator());
    }
}