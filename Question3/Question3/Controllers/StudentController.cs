using Microsoft.AspNetCore.Mvc;
using Question3.Models;
using System.Collections.Generic;

namespace Question3.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<Student> _students = new()
        {
            new Student { StudentId = 1, Name = "Nishanth", Course = "MCA", Email = "nishanthhs@gmail.com" },
            new Student { StudentId = 2, Name = "Ayush", Course = "BE", Email = "Ayushdhiman@gmail.com" }
        };
        public IActionResult Index()
        {
            return View(_students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);
            student.StudentId = _students.Count > 0 ? _students[^1].StudentId + 1 : 1;
            _students.Add(student);
            return RedirectToAction(nameof(Index));
        }
    }
}
