using JoF.Imparta.TaskList.Api.Domain.Models;

namespace JoF.Imparta.TaskList.Api.Domain.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllByUserIdAsync(Guid userId);

    Task<TaskItem> GetById(Guid taskId);

    Task<TaskItem> CreateAsync(TaskItem taskItem);

    Task<bool> DeleteAsync(Guid taskId);

    Task<TaskItem> UpdateAsync(TaskItem taskItem);

    Task<ProfileItem> CreateAsync(ProfileItem profileItem);

    Task<ProfileItem> GetProfileImageAsync(Guid userId);
}
