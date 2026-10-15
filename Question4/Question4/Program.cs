using Microsoft.EntityFrameworkCore;
using Question4.Data;
using Question4.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
                  "Server=(localdb)\\mssqllocaldb;Database=ProductsDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
db.Database.EnsureCreated();
if (!db.Products.Any())
{
    db.Products.AddRange(new[] {
        new Product{ProductName="Keyboard",Category="Electronics",Price=29.99m,Quantity=10},
        new Product{ProductName="Mouse",Category="Electronics",Price=19.99m,Quantity=15},
        new Product{ProductName="Coffee Mug",Category="Kitchen",Price=9.99m,Quantity=30}
    });
    db.SaveChanges();
}

if (!app.Environment.IsDevelopment()) { app.UseExceptionHandler("/Home/Error"); app.UseHsts(); }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
