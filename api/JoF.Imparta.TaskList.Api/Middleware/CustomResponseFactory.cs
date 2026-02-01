namespace JoF.Imparta.TaskList.Api.Middleware;

using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.Logging;

public class CustomResponseFactory
{
    private readonly IEnumerable<ICustomResponse> customResponses;
    private readonly ICustomResponse defaultResponse;
    private readonly ILogger<CustomResponseFactory> logger;

    public CustomResponseFactory(IEnumerable<ICustomResponse> customResponses, DefaultCustomResponse defaultResponse, ILogger<CustomResponseFactory> logger)
    {
        this.customResponses = customResponses;
        this.defaultResponse = defaultResponse;
        this.logger = logger;
    }

    public ICustomResponse Create(int statusCode)
    {
        var handler = customResponses.FirstOrDefault(h => statusCode >= h.StatusCodeMinValue && statusCode <= h.StatusCodeMaxValue);
        logger.LogDebug($"{handler?.ToString() ?? "Handler not found"} for status code of {{StatusCode}}", statusCode);

        return handler ?? defaultResponse;
    }
}
