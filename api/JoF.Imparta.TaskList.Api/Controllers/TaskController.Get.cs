using JoF.Imparta.TaskList.Api.Domain.Models;

using Microsoft.AspNetCore.Mvc;

namespace JoF.Imparta.TaskList.Api.Controllers;

public partial class TaskController
{
    /// <summary>
    /// Get a list of all tasks.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>A <see cref="OkObjectResult"/> list of tasks.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(CommonApiResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] Guid userId)
    {
        logger.LogInformation("Getting all tasks for user.");

        var tasks = await taskService.GetAllByUserIdAsync(userId);

        return this.Ok(tasks);
    }
}
