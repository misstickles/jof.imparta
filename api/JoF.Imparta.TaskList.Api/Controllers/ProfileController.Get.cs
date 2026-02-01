namespace JoF.Imparta.TaskList.Api.Controllers;

using JoF.Imparta.TaskList.Api.Domain.Models;

using Microsoft.AspNetCore.Mvc;

public partial class ProfileController
{
    /// <summary>
    /// Gets the specified user's profile image
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>The profile image as a Base64 string.</returns>
    /// <remarks>Example GUID: 321902d1-1115-42ae-b874-cb9f2d2c1064</remarks>
    [HttpGet("{userId:guid}")]
    [ProducesResponseType(typeof(ProfileItem), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid userId)
    {
        logger.LogInformation("Getting profile for user");

        var profile = await profileService.GetByUserIdAsync(userId);

        return this.Ok(profile);
    }
}
