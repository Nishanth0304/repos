using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace Question4.Middleware
{
    public class ProductIdValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ProductIdValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Only validate for the ProductDetails route
            var path = context.Request.Path.Value ?? string.Empty;
            if (path.StartsWith("/Store/ProductDetails", System.StringComparison.OrdinalIgnoreCase))
            {
                // Route values are available after UseRouting
                var routeId = context.GetRouteValue("id");
                if (routeId == null)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid Product ID: missing");
                    return;
                }

                if (!int.TryParse(routeId.ToString(), out var id) || id <= 0)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Invalid Product ID");
                    return;
                }
            }

            await _next(context);
        }
    }
}
