namespace JoF.Imparta.TaskList.Api.Extensions;

using Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtensions
{
    public static WebApplication UseCustomMiddleware(
        this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerUI(options =>
            {
                var descriptions = app.DescribeApiVersions();

                foreach (var desc in descriptions)
                {
                    var url = $"/openapi/{desc.GroupName}.json";
                    var name = desc.GroupName.ToLowerInvariant();
                    options.SwaggerEndpoint(url, name);
                }

                //        options.SwaggerEndpoint("/openapi/v1.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.Use((context, next) =>
        {
            context.Response.Headers.Append("X-ApiSource", "Jo's Simple Task List");
            return next.Invoke();
        });

        app.MapControllerRoute(name: "default", pattern: "api/{controller}/{action}");

        return app;
    }
}
