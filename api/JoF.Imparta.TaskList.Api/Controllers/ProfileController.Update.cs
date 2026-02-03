namespace JoF.Imparta.TaskList.Api.Controllers;

using FluentValidation;

using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Validation;

using Microsoft.AspNetCore.Mvc;

public partial class ProfileController
{
    public class CreateProfileQuery
    {
        public Guid UserId { get; set; }
        public string ImageBase64 { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }

    public class CreateProfileQueryValidator : AbstractValidator<CreateProfileQuery>
    {
        public CreateProfileQueryValidator() {
            this.SetRules();
        }

        private void SetRules()
        {
            this.RuleFor(q => q.UserId)
                .SetValidator(new UserIdValidator());
            this.RuleFor(q => q.ImageBase64)
                .SetValidator(new ImageValidator());
        }
    }

    /// <summary>
    /// Stores a profile image for the given user.
    /// </summary>
    /// <param name="query">The <see cref="Query"/>.</param>
    /// <returns>The base64 string.  An exception is included if not successful.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProfileItem), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateProfileQuery query)
    {
        logger.LogInformation("Uploading profile");

        var profile = await profileService.UploadAsync(query.UserId, query.ImageBase64, query.ContentType);

        return this.Ok(profile);
    }
}
