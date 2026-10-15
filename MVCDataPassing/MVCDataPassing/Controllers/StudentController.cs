using Microsoft.AspNetCore.Mvc;
using MVCDataPassing.Models;

namespace MVCDataPassing.Controllers
{
    public class StudentController : Controller
    {
        // /Student
        public IActionResult Index()
        {
            string name = "Nishanth";

            return View("Index", name);
        }

        // /Student/Input
        [HttpGet]
        public IActionResult Input()
        {
            return View();
        }

        // /Student/Submit
        [HttpPost]
        public IActionResult Submit(string name)
        {
            return Content("You entered: " + name);
        }

        // /Student/Details
        [HttpGet]
        public IActionResult Details()
        {
            var student = new Student
            {
                Id = 1,
                Name = "Nishanth",
                Course = "MCA"
            };

            return View(student);
        }
    }
}