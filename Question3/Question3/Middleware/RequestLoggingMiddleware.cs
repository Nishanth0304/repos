using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Question3.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            var method = context.Request.Method;
            var time = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
            var endpoint = context.GetEndpoint();
            var endpointName = endpoint?.DisplayName ?? "(none)";
            _logger.LogInformation("Request: {Method} {Path} | Time: {Time} | Endpoint: {Endpoint}", method, path, time, endpointName);
            Console.WriteLine($"Request: {method} {path}");
            Console.WriteLine($"Time: {time}");
            Console.WriteLine($"Matched endpoint: {endpointName}");
            await _next(context);
        }
    }
}
