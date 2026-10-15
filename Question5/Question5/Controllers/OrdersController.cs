using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Question5.Data;

namespace Question5.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Products)
                .ToListAsync();

            return View(orders);
        }
    }
}