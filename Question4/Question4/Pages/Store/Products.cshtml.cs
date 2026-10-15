using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Question4.Data;
using Question4.Models;

namespace Question4.Pages.Store
{
    public class ProductsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ProductsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Product> ProductList { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            ProductList = await _db.Products.ToListAsync();
        }
    }
}
