namespace JoF.Imparta.TaskList.Api.Middleware;

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class DefaultCustomResponse : ICustomResponse
{
    private readonly ILogger<DefaultCustomResponse> logger;
    private readonly JsonSerializerOptions jsonSerializerOptions;

    public DefaultCustomResponse(
        IOptions<JsonSerializerOptions> jsonSerializerOptions,
        ILogger<DefaultCustomResponse> logger)
    {
        this.jsonSerializerOptions = jsonSerializerOptions?.Value ?? new JsonSerializerOptions();
        this.logger = logger;
    }

    public int StatusCodeMinValue { get; }

    public int StatusCodeMaxValue { get; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Major Code Smell",
        "S3900:Arguments of public methods should be validated against null",
        Justification = "Using Guard")]
    public async Task HandleRequestAsync(HttpContext context, string result, ApiMiddlewareOptions options)
    {
        Guard.ArgumentNotNull(context, nameof(context));

        var apiVersion = context.GetRequestedApiVersion();

        logger.LogDebug("Request failed with {StatusCode} and {Result}", context.Response.StatusCode, result);

        var errorMessage = JsonHelper.ValidJsonObject(result);

        context.Response.StatusCode = (int)this.GetResponseStatusCode(errorMessage.ToString(), options);

        var apiResponse = new ApiResponse
        {
            Errors = new List<ApiError>
            {
                new ApiError { Message = errorMessage }
            },
            Path = context.Request.Path,
            StatusCode = context.Response.StatusCode,
            HasErrors = true,
            Version = $"{apiVersion?.MajorVersion}"
        };

        var serializedResponse = JsonSerializer.Serialize(apiResponse, this.jsonSerializerOptions);
        context.Response.ContentLength = Encoding.UTF8.GetByteCount(serializedResponse);

        await context.Response.WriteAsync(serializedResponse);
    }

    private HttpStatusCode GetResponseStatusCode(string errorMessage, ApiMiddlewareOptions options)
    {
        foreach (var (key, value) in options.CustomExceptionStatusCodes)
        {
            if (errorMessage.Contains($"Exceptions.{key}", StringComparison.InvariantCulture))
            {
                return value;
            }
        }

        return HttpStatusCode.InternalServerError;
    }
}