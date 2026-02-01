using JoF.Imparta.TaskList.Api.Domain.Models;

using Microsoft.AspNetCore.Mvc;

namespace JoF.Imparta.TaskList.Api.Controllers;

public partial class TasksController
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TaskItem>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] Guid userId)
    {
        this.logger.LogInformation("Getting all tasks for user.");

        var tasks = await this.taskService.GetAllByUserIdAsync(userId);

        return this.Ok(tasks);
    }
}
