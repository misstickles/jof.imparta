
namespace JoF.Imparta.TaskList.Api.Domain.Services;

using JoF.Imparta.TaskList.Api.Domain.Models;

public class TaskService : ITaskService
{
    public Task<TaskItem> CreateAsync(TaskItem newTask)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(Guid taskId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TaskItem>> GetAllByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<object> UpdateAsync(Guid taskId, object newTask)
    {
        throw new NotImplementedException();
    }

    public Task<object> UpdateStatusAsync(Guid taskId, Models.TaskStatus newStatus)
    {
        throw new NotImplementedException();
    }
}
