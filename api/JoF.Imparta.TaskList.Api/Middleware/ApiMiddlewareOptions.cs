namespace JoF.Imparta.TaskList.Api.Middleware;

using System;
using System.Collections.Concurrent;
using System.Net;

public class ApiMiddlewareOptions
{
    /// <summary>
    /// Gets or sets the custom exception status codes.
    /// </summary>
    /// <value>
    /// The custom exception status codes.
    /// If required, map a custom Exception to use a custom HttpStatusCode.
    /// </value>
    /// <example>
    /// opt.Map CustomException (HttpStatusCode(418));
    /// </example>
    public ConcurrentDictionary<string, HttpStatusCode> CustomExceptionStatusCodes { get; } = new ConcurrentDictionary<string, HttpStatusCode>();

    public string? GenericMessage { get; set; }

    /// <summary>
    /// Gets or sets the response format exclude - to avoid reformatting the response (eg, if returning bytes)
    /// </summary>
    /// <value>
    /// The response format exclude.
    /// </value>
    public string[]? ResponseFormatExclude { get; set; }

    public void Map<TException>(HttpStatusCode statusCode)
        where TException : Exception
    {
        var name = typeof(TException).Name;

        if (this.CustomExceptionStatusCodes.TryAdd(name, statusCode))
        {
            return;
        }

        if (this.CustomExceptionStatusCodes.TryRemove(name, out _))
        {
            this.CustomExceptionStatusCodes.TryAdd(name, statusCode);
        }
    }
}
