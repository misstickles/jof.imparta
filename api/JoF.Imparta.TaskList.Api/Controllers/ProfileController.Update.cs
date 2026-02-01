using FluentValidation;

using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Validation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace JoF.Imparta.TaskList.Api.Controllers;

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
        }

    }

    /// <summary>
    /// Stores a profile image for the given user.
    /// </summary>
    /// <param name="query">The <see cref="Query"/>.</param>
    /// <returns>True if successful, False with the exception if not successful</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProfileItem), StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] Query query)
    {
        var profile = await this.profileService.UpdloadAsync(query.UserId, query.ImageBase64String);

        return this.Ok(profile);
    }
}
