namespace MiddlewareDemo.Middleware
{
    public class SecondMiddleware
    {
        private readonly RequestDelegate _next;

        public SecondMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Second Middleware - Before");

            await _next(context);

            Console.WriteLine("Second Middleware - After");
        }
    }
}