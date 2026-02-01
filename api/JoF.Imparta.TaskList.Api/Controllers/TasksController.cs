namespace JoF.Imparta.TaskList.Api.Controllers;

using Asp.Versioning;

using JoF.Imparta.TaskList.Api.Domain.Services;

using Microsoft.AspNetCore.Mvc;

[ApiVersion("1")]
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public partial class TasksController(ILogger<TasksController> logger, ITaskService taskService) : ControllerBase
{
    private readonly ILogger<TasksController> logger;
    private readonly ITaskService taskService;
}
