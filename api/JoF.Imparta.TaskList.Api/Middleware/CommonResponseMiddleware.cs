namespace JoF.Imparta.TaskList.Api.Middleware;

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using JoF.Imparta.TaskList.Api.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

/// <summary>
/// Wraps all responses in a common JSON response.
/// </summary>
public class CommonResponseMiddleware
{
    private readonly RequestDelegate next;
    private readonly CustomResponseFactory responseFactory;
    private readonly ApiMiddlewareOptions options;
    private readonly ILogger<CommonResponseMiddleware> logger;
    private readonly JsonSerializerOptions jsonSerializerOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommonResponseMiddleware"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <param name="next">The next component in the pipeline.</param>
    /// <param name="responseFactory">A factory to build the correct response handler</param>
    /// <param name="logger">The logger.</param>
    /// <param name="jsonSerializerOptions">The MVC json options.</param>
    public CommonResponseMiddleware(
        ApiMiddlewareOptions options,
        RequestDelegate next,
        CustomResponseFactory responseFactory,
        ILogger<CommonResponseMiddleware> logger,
        IOptions<JsonSerializerOptions> jsonSerializerOptions)
    {
        this.next = next;
        this.responseFactory = responseFactory;
        this.logger = logger;
        this.options = options;
        this.jsonSerializerOptions = jsonSerializerOptions?.Value ?? new JsonSerializerOptions();
    }

    /// <summary>
    /// Asynchronous method invoked in the middleware pipeline
    /// </summary>
    /// <param name="context">The context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        var existingBody = context.Response.Body;

        await using var newBody = new MemoryStream();
        context.Response.Body = newBody;

        try
        {
            await this.next(context);

            context.Response.Body = existingBody;
            context.Response.ContentType = "application/json";

            var result = await FormatResponseAsync(newBody);

            await this.BuildApiResponseAsync(context, result);
        }
        catch (Exception exception)
        {
            context.Response.Body = existingBody;
            await this.HandleExceptionAsync(context, exception);
        }
    }

    private async Task BuildApiResponseAsync(HttpContext context, string result)
    {
        var statusCode = context.Response.StatusCode;

        var responseProcessor = responseFactory.Create(statusCode);

        await responseProcessor.HandleRequestAsync(context, result, this.options);
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)GetResponseStatusCode(exception);
        var apiVersion = context.GetRequestedApiVersion();

        var apiResponse = new ApiResponse
        {
            Errors = new List<ApiError> {
                new ApiError
                {
                    Message = exception.Message
                              ?? this.options.GenericMessage
                              ?? "An error has occurred.",
                    Type = nameof(exception)
                }
            },
            HasErrors = true,
            Id = Guid.NewGuid().ToString(),
            Path = context.Request.Path,
            StatusCode = context.Response.StatusCode,
            Version = $"{apiVersion?.MajorVersion}"
        };

        var innerExceptionMessage = GetInnermostExceptionMessage(exception);

        this.logger.Log(LogLevel.Error, exception, $"ERROR {innerExceptionMessage}.", apiResponse.Id);

        var serialisedResponse = JsonSerializer.Serialize(apiResponse, this.jsonSerializerOptions);
        context.Response.ContentLength = Encoding.UTF8.GetByteCount(serialisedResponse);

        await context.Response.WriteAsync(serialisedResponse);
    }

    private static HttpStatusCode GetResponseStatusCode(Exception exception)
    {
        return exception switch
        {
            PageDoesNotExistException _ => HttpStatusCode.BadRequest,
            InvalidQueryException _ => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };
    }


    private static async Task<string> FormatResponseAsync(Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);

        using var sr = new StreamReader(stream);

        return await sr.ReadToEndAsync();
    }

    [Pure]
    private static string GetInnermostExceptionMessage(Exception exception)
    {
        return exception.InnerException != null
            ? GetInnermostExceptionMessage(exception.InnerException)
            : exception.Message;
    }
}
