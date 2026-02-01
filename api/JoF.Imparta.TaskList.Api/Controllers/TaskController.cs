namespace JoF.Imparta.TaskList.Api.Controllers;

using Asp.Versioning;

using JoF.Imparta.TaskList.Api.Domain.Services;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Manage the tasks.
/// </summary>
/// <param name="logger"></param>
/// <param name="taskService"></param>
[ApiVersion("1")]
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public partial class TaskController(ILogger<TaskController> logger, ITaskService taskService) : ControllerBase
{
}
