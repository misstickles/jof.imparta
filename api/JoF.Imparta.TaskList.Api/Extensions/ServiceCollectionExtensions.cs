namespace JoF.Imparta.TaskList.Api.Extensions;

using Asp.Versioning;
using FluentValidation;
using JoF.Imparta.TaskList.Api.Domain.Extensions;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApiServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddValidatorsFromAssemblyContaining<Program>();
        services.AddFluentValidationAutoValidation();

        services.AddLogging(builder => builder.AddConsole());

        services.AddApiVersioning(
            options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = false;
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        services.AddTaskListServices();
    }
}
