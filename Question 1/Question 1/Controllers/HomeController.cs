using Microsoft.AspNetCore.Mvc;
using Question_1.Models;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
namespace Question_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Question_1.Models.Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);
            return View("Confirmation", employee);
        }
    }
}