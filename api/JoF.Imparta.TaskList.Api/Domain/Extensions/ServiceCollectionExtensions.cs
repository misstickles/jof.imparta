namespace JoF.Imparta.TaskList.Api.Domain.Extensions;

using JoF.Imparta.TaskList.Api.Domain.Services;
using JoF.Imparta.TaskList.Api.Validation;
//using JoF.Imparta.TaskList.Api.Profiles;

public static class ServiceCollectionExtensions
{
    public static void AddTaskServices(this IServiceCollection services)
    {
        Guard.ArgumentNotNull(services, nameof(services));

//        services.AddAutoMapper(typeof(TasksProfile));

        //services.AddScoped<IProfileService, ProfileService>();
        //services.AddScoped<ITaskService, TaskService>();
    }
}
