using Microsoft.AspNetCore.Mvc;

namespace question2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details()
        {
        
            ViewBag.ProductID = 101;
            ViewBag.ProductName = "Laptop";
            ViewBag.Price = "₹75,000";

            return View();
        }
    }
}
