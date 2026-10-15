using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Question4.Data;
using Question4.Models;

namespace Question4.Pages.Store
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ProductDetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product? Product { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return BadRequest();

            if (id <= 0)
                return BadRequest("Invalid Product ID");

            Product = _db.Products.Find(id.Value);
            if (Product == null)
                return NotFound();

            return Page();
        }
    }
}
