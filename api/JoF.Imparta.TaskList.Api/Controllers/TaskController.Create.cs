namespace JoF.Imparta.TaskList.Api.Controllers;

using FluentValidation;

using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Validation;

using Microsoft.AspNetCore.Mvc;

public partial class TaskController
{
    public class CreateTaskQuery
    {
        public string? Description { get; set; }
        
        public required string Title { get; set; }
        
        public Guid UserId { get; set; }
    }

    public class CreateTaskQueryValidator : AbstractValidator<CreateTaskQuery>
    {
        public CreateTaskQueryValidator()
        {
            this.SetRules();
        }

        private void SetRules()
        {
            this.RuleFor(q => q.UserId)
                .SetValidator(new UserIdValidator());
            this.RuleFor(q => q.Title)
                .NotNull()
                .NotEmpty();
        }
    }

    /// <summary>
    /// Creates a provided task
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CommonApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateTask([FromBody] CreateTaskQuery query)
    {
        logger.LogInformation("Creating a new task.");

        var result = await taskService.CreateAsync(query.UserId, query.Title, query.Description);

        return this.Ok(result);
    }

}
