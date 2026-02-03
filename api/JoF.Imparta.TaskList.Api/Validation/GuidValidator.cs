namespace JoF.Imparta.TaskList.Api.Validation;

using FluentValidation;

public class GuidValidator : AbstractValidator<Guid>
{
    public GuidValidator()
    {
        RuleFor(guid => guid)
            .NotNull()
            .NotEmpty()
            .WithMessage("Guid must be valid and not null or empty");
    }
}
