namespace JoF.Imparta.TaskList.Api.Domain.Services;

using JoF.Imparta.TaskList.Api.Domain.Models;

public interface ITaskService
{
    /// <summary>
    /// Get all task items.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>A <see cref="IEnumerable{TaskItem}"/>.</returns>
    Task<IEnumerable<TaskItem>> GetAllByUserIdAsync(Guid userId);

    /// <summary>
    /// Create a new task item.
    /// </summary>
    /// <param name="newTask">The new task item.</param>
    /// <returns>The created <see cref="TaskItem"/>.</returns>
    Task<TaskItem> CreateAsync(TaskItem newTask);

    /// <summary>
    /// Delete the specified task by id.
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <returns>A <see cref="bool"/> of success.</returns>
    Task<bool> DeleteByIdAsync(Guid taskId);

    /// <summary>
    /// Update the specified task item.
    /// </summary>
    /// <param name="id">The task id.</param>
    /// <param name="newTask">The new task.</param>
    /// <returns></returns>
    Task<object> UpdateAsync(Guid taskId, object newTask);

    /// <summary>
    /// Update the task status of the specified task.
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="newStatus">The new status.</param>
    /// <returns></returns>
    /// <remarks>Note: if using is outside namespace, TaskStatus conflicts with System.Threading.Tasks.TaskStatus...</remarks>
    Task<object> UpdateStatusAsync(Guid taskId, TaskStatus newStatus);
}
