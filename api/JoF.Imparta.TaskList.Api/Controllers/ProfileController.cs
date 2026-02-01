namespace JoF.Imparta.TaskList.Api.Controllers;

using Asp.Versioning;

using JoF.Imparta.TaskList.Api.Domain.Services;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Manage a user's profile.
/// </summary>
/// <param name="logger"></param>
/// <param name="profileService"></param>
[ApiVersion("1")]
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public partial class ProfileController(ILogger<ProfileController> logger, IProfileService profileService) : ControllerBase
{
    private readonly ILogger<ProfileController> logger;
    private readonly IProfileService profileService;
}
