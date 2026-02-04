namespace JoF.Imparta.TaskList.Api.Middleware;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public interface ICustomResponse
{
    int StatusCodeMinValue { get; }

    int StatusCodeMaxValue { get; }

    Task HandleRequestAsync(HttpContext context, string result, ApiMiddlewareOptions options);
}
