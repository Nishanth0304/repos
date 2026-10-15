namespace MiddlewareDemo.Middleware
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Custom Middleware - Before");

            await _next(context);

            Console.WriteLine("Custom Middleware - After");
        }
    }
}