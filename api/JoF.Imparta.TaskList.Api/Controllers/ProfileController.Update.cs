namespace JoF.Imparta.TaskList.Api.Controllers;

using FluentValidation;

using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Validation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

public partial class ProfileController
{
    public class Query : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public string ImageBase64String { get; set; } = string.Empty;
    }

    public class QueryValidator : AbstractValidator<Query>
    {
        public QueryValidator() {
            this.SetRules();
        }

        private void SetRules()
        {
            this.RuleFor(q => q.UserId)
                .SetValidator(new UserIdValidator());
            this.RuleFor(q => q.ImageBase64String)
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
    public async Task<IActionResult> Post([FromBody] Query query)
    {
        logger.LogInformation("Uploading profile");

        var profile = await profileService.UpdloadAsync(query.UserId, query.ImageBase64String);

        return this.Ok(profile);
    }
}
