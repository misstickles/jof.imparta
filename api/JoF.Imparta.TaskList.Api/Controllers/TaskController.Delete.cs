namespace JoF.Imparta.TaskList.Api.Controllers;

using FluentValidation;

using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Validation;

using Microsoft.AspNetCore.Mvc;

public partial class TaskController
{
    public class DeleteTaskQuery
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
    }

    public class DeleteTaskQueryValidator : AbstractValidator<DeleteTaskQuery>
    {
        public DeleteTaskQueryValidator()
        {
            this.SetRules();
        }

        private void SetRules()
        {
            this.RuleFor(q => q.UserId)
                .SetValidator(new UserIdValidator());
            this.RuleFor(q => q.TaskId)
                .SetValidator(new GuidValidator());
        }
    }

    /// <summary>
    /// Deleted the given task
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpDelete()]
    [ProducesResponseType(typeof(CommonApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteTask([FromBody] DeleteTaskQuery query)
    {
        logger.LogInformation("Deleting task.");

        var result = await taskService.DeleteByIdAsync(query.TaskId, query.UserId);

        return this.Ok(result);
    }

}
