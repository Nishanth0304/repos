var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<MyMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
