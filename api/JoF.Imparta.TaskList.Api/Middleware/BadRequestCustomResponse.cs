// Copyright (c) 2020, Elekta, AB

namespace JoF.Log.Exporter.Api.Middleware
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    using JoF.Imparta.TaskList.Api.Guards;
    using JoF.Imparta.TaskList.Api.Middleware;
    using JoF.Imparta.TaskList.Api.Models;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.Extensions.Options;

    public class BadRequestCustomResponse : ICustomResponse
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public int StatusCodeMinValue => StatusCodes.Status400BadRequest;

        public int StatusCodeMaxValue => StatusCodes.Status400BadRequest;

        public BadRequestCustomResponse(IOptions<JsonSerializerOptions> jsonSerializerOptions)
        {
            this.jsonSerializerOptions = jsonSerializerOptions?.Value ?? new JsonSerializerOptions();
        }

        public async Task HandleRequestAsync(HttpContext context, string result, ApiMiddlewareOptions options)
        {
            Guard.ArgumentNotNull(context, nameof(context));

            var response = JsonSerializer.Deserialize<BadRequest>(result);

            var errors = response.Error == null
                ? response.Errors?.SelectMany(e => e.Value
                    .Select(v => new ApiError
                    {
                        Message = v,
                        Field = e.Key
                    }))
                : new List<ApiError>
                {
                    new ApiError
                    {
                        Message = response.Error?.Message,
                        Field = response.Error?.Code
                    }
                };

            var apiVersion = context.GetRequestedApiVersion();

            var apiResponse = new ApiResponse
            {
                Errors = errors,
                HasErrors = true,
                Path = context.Request.Path,
                StatusCode = context.Response.StatusCode,
                Version = apiVersion?.MajorVersion.ToString()
            };

            var serialisedResponse = JsonSerializer.Serialize(apiResponse, this.jsonSerializerOptions);
            context.Response.ContentLength = Encoding.UTF8.GetByteCount(serialisedResponse);

            await context.Response.WriteAsync(serialisedResponse);
        }
    }
}
