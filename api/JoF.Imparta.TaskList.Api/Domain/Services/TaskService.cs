
namespace JoF.Imparta.TaskList.Api.Domain.Services;

using JoF.Imparta.TaskList.Api.Domain.Exceptions;
using JoF.Imparta.TaskList.Api.Domain.Models;
using JoF.Imparta.TaskList.Api.Domain.Repositories;

public class TaskService(ILogger<TaskService> logger, ITaskRepository repository) : ITaskService
{
    /// <inheritdoc/>
    public async Task<CommonApiResponse> CreateAsync(Guid userId, string title, string? description)
    {
        var errors = new List<CommonApiError>();
        var response = new CommonApiResponse
        {
            Errors = null,
            HasErrors = false
        };

        try
        {
            response.Result = await repository.CreateAsync(new TaskItem
            {
                DateCreated = DateTime.UtcNow,
                Description = description,
                Id = Guid.NewGuid(),
                Status = TaskStatus.Pending,
                Title = title,
                UserId = userId
            });
        }
        catch (Exception ex) {
            logger.LogError(ex.Message);

            errors.Add(new CommonApiError
            {
                Message = $"Unknown Error"
            });

            response.HasErrors = true;
        }

        return response;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteByIdAsync(Guid taskId, Guid userId)
    {
        var deleted = false;

        try
        {
            // get the task to ensure we are allowed to delete it
            var task = await repository.GetById(taskId);

            if (task is null || !task.UserId.Equals(userId))
            {
                throw new TaskNotFoundException(); // wrong exception, but for simplicity!
            }

            deleted = await repository.DeleteAsync(taskId);
        }
        catch (TaskNotFoundException tnfex)
        {
            logger.LogError(tnfex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }

        return deleted;
    }

    /// <inheritdoc/>
    public async Task<CommonApiResponse> GetAllByUserIdAsync(Guid userId)
    {
        var errors = new List<CommonApiError>();
        var response = new CommonApiResponse
        {
            HasErrors = false,
            Errors = null,
        };

        try
        {
            response.Result = await repository.GetAllByUserIdAsync(userId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);

            response.HasErrors = true;
            errors.Add(new()
            {
                Message = "Unknown Error"
            });
        }

        return response;
    }

    /// <inheritdoc/>
    public async Task<CommonApiResponse> UpdateAsync(Guid taskId, string? title, string? description, TaskStatus? status)
    {
        var errors = new List<CommonApiError>();
     
        var response = new CommonApiResponse
        {
            Errors = null,
            HasErrors = false,
        };

        try
        {
            var existing = await repository.GetById(taskId);
            if (description is not null) existing.Description = description;
            if (title is not null) existing.Title = title;
            if (status is not null) existing.Status = status ?? TaskStatus.Pending;

            response.Result = await repository.UpdateAsync(existing);
        }
        catch (TaskNotFoundException tnfex)
        {
            logger.LogError(tnfex.Message);

            errors.Add(new CommonApiError
            {
                Message = tnfex.Message
            });

            response.HasErrors = true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);

            errors.Add(new CommonApiError
            {
                Message = "Unknown Error"
            });

            response.HasErrors = true;
        }

        return response;
    }
}
