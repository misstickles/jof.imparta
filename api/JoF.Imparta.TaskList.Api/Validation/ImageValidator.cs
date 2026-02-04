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

    // // https://en.wikipedia.org/wiki/List_of_file_signatures
    // private readonly byte[][] validImagePrefixBytes = [
    //     [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A],              // png
    //     [0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01],              // jpg / jpeg
    //     [0xFF, 0xD8, 0xFF, 0xEE],                                      // jpg / jpeg
    //     [0xFF, 0xD8, 0xFF, 0xE1], //, ?? ?? 45 78 69 66 00 00],        // jpg / jpeg
    //     [0xFF, 0xD8, 0xFF, 0xE0],                                      // jpg
    //     [0x47, 0x49, 0x46, 0x38, 0x37, 0x61],                          // gif
    //     [0x47, 0x49, 0x46, 0x38, 0x39, 0x61]                           // gif
    //  ];

    public ImageValidator()
    {
        RuleFor(s => s)
            .NotNull()
            .NotEmpty()
            .Must((i) => validBase64ImagePrefixes.Any(p => i.StartsWith(p)))
            .WithMessage("Image must be of type 'gif', 'png' or 'jp*g'");
    }
}