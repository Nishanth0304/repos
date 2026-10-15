using Microsoft.AspNetCore.Diagnostics;
using MiddlewareDemo.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();


// Developer Exception Page
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(
        new DeveloperExceptionPageOptions
        {
            SourceCodeLineCount = 10
        });
}


// Custom Middleware 1
app.UseMiddleware<MyCustomMiddleware>();


// Custom Middleware 2
app.UseMiddleware<SecondMiddleware>();


// Static Files Middleware
app.UseStaticFiles();


// Routing
app.UseRouting();


// MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();