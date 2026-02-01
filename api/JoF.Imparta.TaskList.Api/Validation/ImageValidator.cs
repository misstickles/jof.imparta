namespace JoF.Imparta.TaskList.Api.Validation;

using FluentValidation;

public class ImageValidator : AbstractValidator<string>
{
    private readonly string[] validBase64ImagePrefixes = [
        "R0lGODdh",     // image/gif
        "R0lGODlh",     // image/gif
        "iVBORw0KGgo",  // image/png
        "/9j/",         // image/jpeg
    ];

    public ImageValidator()
    {
        RuleFor(s => s)
            .NotNull()
            .NotEmpty()
            .Must((f) => validBase64ImagePrefixes.Any(i => f.StartsWith(i)))
            .WithMessage("Image must be of type 'gif', 'png' or 'jpeg'");
    }
}