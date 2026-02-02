namespace JoF.Imparta.TaskList.Api.Domain.Extensions;

using JoF.Imparta.TaskList.Api.Domain.Guards;
using JoF.Imparta.TaskList.Api.Domain.Repositories;
using JoF.Imparta.TaskList.Api.Domain.Services;

public static class ServiceCollectionExtensions
{
    public static void AddTaskListServices(this IServiceCollection services)
    {
        Guard.ArgumentNotNull(services, nameof(services));

        services.AddSingleton<ITaskRepository, ListTaskRepository>();

        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<ITaskService, TaskService>();
    }
}
