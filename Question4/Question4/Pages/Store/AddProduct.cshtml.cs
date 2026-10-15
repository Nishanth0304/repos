using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Question4.Data;
using Question4.Models;

namespace Question4.Pages.Store
{
    public class AddProductModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AddProductModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Product Product { get; set; } = new Product();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Products.Add(Product);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Store/Products");
        }
    }
}
