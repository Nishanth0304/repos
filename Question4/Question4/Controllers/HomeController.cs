using Microsoft.AspNetCore.Mvc;
using Question4.Models;
using System.Diagnostics;

namespace Question4.Controllers
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
    }
}
