namespace JoF.Imparta.TaskList.Api.Controllers;

using FluentValidation;

using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Validation;

using Microsoft.AspNetCore.Mvc;

public partial class TaskController
{
    public class UpdateTaskQuery
    {
        public Guid TaskId { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public TaskStatus Status { get; set; }
    }

    public class UpdateTaskQueryValidator : AbstractValidator<UpdateTaskQuery>
    {
        public UpdateTaskQueryValidator()
        {
            this.SetRules();
        }

        private void SetRules()
        {
            this.RuleFor(q => q.TaskId)
                .SetValidator(new GuidValidator());

            this.RuleFor(q => q.Status)
                .Must(m => Enum.IsDefined(m))
                .WithMessage("Status must be a valid task status (0, 1, 2) or ('Pending', 'InProgress', 'Completed')");
        }
    }

    /// <summary>
    /// Updates the given task
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(CommonApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskQuery query)
    {
        logger.LogInformation("Updating the task.");

        var result = await taskService.UpdateAsync(query.TaskId, query.Title, query.Description, query.Status);

        return this.Ok(result);
    }

}
