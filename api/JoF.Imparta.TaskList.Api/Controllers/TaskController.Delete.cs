namespace JoF.Imparta.TaskList.Api.Controllers;

using JoF.Imparta.TaskList.Api.Domain.Models;

using Microsoft.AspNetCore.Mvc;

public partial class TaskController
{
    /// <summary>
    /// Deleted the given task
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="userId">The user id.</param>
    /// <returns></returns>
    [HttpDelete("{taskId:guid}")]
    [ProducesResponseType(typeof(CommonApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteTask([FromRoute] Guid taskId, [FromQuery] Guid userId)
    {
        logger.LogInformation("Deleting task.");

        var result = await taskService.DeleteByIdAsync(taskId, userId);

        return this.Ok(result);
    }
}
