namespace JoF.Imparta.TaskList.Api.Middleware;

using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using JoF.Imparta.TaskList.Api.Guards;
using JoF.Imparta.TaskList.Api.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

public class SuccessCustomResponse : ICustomResponse
{
    private const int StatusCodeMaxRangeValue = 299;
    private readonly JsonSerializerOptions jsonSerializerOptions;

    public SuccessCustomResponse(IOptions<JsonSerializerOptions> jsonSerializerOptions)
    {
        this.jsonSerializerOptions = jsonSerializerOptions?.Value ?? new JsonSerializerOptions();
    }

    public int StatusCodeMinValue => StatusCodes.Status200OK;

    public int StatusCodeMaxValue => StatusCodeMaxRangeValue;

    public async Task HandleRequestAsync(HttpContext context, string result, ApiMiddlewareOptions options)
    {
        Guard.ArgumentNotNull(context, nameof(context));

        var apiVersion = context.GetRequestedApiVersion();

        var apiResponse = new ApiResponse
        {
            Path = context.Request.Path,
            StatusCode = context.Response.StatusCode,
            Result = JsonHelper.ValidJsonObject(result),
            HasErrors = false,
            Version = $"{apiVersion?.MajorVersion}"
        };

        var serializedResponse = JsonSerializer.Serialize(apiResponse, this.jsonSerializerOptions);
        context.Response.ContentLength = Encoding.UTF8.GetByteCount(serializedResponse);

        await context.Response.WriteAsync(serializedResponse);
    }
}