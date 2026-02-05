namespace JoF.Imparta.TaskList.Api.Controllers;

using FluentValidation;

using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Validation;

using Microsoft.AspNetCore.Mvc;

public partial class TaskController
{
    public class UpdateTaskQuery
    {
        public string? Description { get; set; }
        public string? Title { get; set; }
        public TaskStatus? Status { get; set; }
    }

    public class UpdateTaskQueryValidator : AbstractValidator<UpdateTaskQuery>
    {
        public UpdateTaskQueryValidator()
        {
            this.SetRules();
        }

        private void SetRules()
        {
            this.When((w) => w.Status is not null, () =>
            {
                this.RuleFor(q => q.Status)
                    .IsInEnum()
                    .WithMessage("Status must be a valid task status (0, 1, 2) or ('Pending', 'InProgress', 'Completed')");
            });
        }
    }

    /// <summary>
    /// Updates the given task
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="query">The update query.</param>
    /// <returns></returns>
    [HttpPut("{taskId:guid}")]
    [ProducesResponseType(typeof(CommonApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateTask([FromRoute] Guid taskId, [FromBody] UpdateTaskQuery query)
    {
        logger.LogInformation("Updating the task.");

        var result = await taskService.UpdateAsync(taskId, query.Title, query.Description, query.Status);

        return this.Ok(result);
    }

}
