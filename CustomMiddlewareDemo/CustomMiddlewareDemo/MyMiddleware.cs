public class MyMiddleware
{
    private readonly RequestDelegate _next;

    public MyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Requested URL: " + context.Request.Path);

        await _next(context);

        Console.WriteLine("Request Completed");
    }
}