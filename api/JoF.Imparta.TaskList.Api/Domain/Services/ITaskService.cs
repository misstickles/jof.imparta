namespace JoF.Imparta.TaskList.Api.Domain.Services;

using JoF.Imparta.TaskList.Api.Domain.Models;

public interface ITaskService
{
    /// <summary>
    /// Get all task items.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>A list of <see cref="TaskItem"/> within a <see cref="CommonApiResponse"/>.</returns>
    Task<CommonApiResponse> GetAllByUserIdAsync(Guid userId);

    /// <summary>
    /// Create a new task item.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <param name="title">The title.</param>
    /// <param name="description">The description.</param>
    /// <returns>The created <see cref="TaskItem"/> within a <see cref="CommonApiResponse"/>.</returns>
    Task<CommonApiResponse> CreateAsync(Guid userId, string title, string? description);

    /// <summary>
    /// Delete the specified task by id.
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="userId">The user id.</param>
    /// <returns>A <see cref="bool"/> of success.</returns>
    Task<bool> DeleteByIdAsync(Guid taskId, Guid userId);

    /// <summary>
    /// Update the specified task item.
    /// </summary>
    /// <param name="id">The task id.</param>
    /// <param name="title">The new title.</param>
    /// <param name="description">[Optional] The new description.</param>
    /// <returns>A new <see cref="CommonApiResponse"/>.</returns>
    Task<CommonApiResponse> UpdateAsync(Guid taskId, string title, string? description);

    /// <summary>
    /// Update the task status of the specified task.
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="newStatus">The new status.</param>
    /// <returns></returns>
    /// <remarks>Note: if using is outside namespace, TaskStatus conflicts with System.Threading.Tasks.TaskStatus...</remarks>
    Task<CommonApiResponse> UpdateStatusAsync(Guid taskId, TaskStatus newStatus);
}
