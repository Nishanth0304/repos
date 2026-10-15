using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Models;

namespace MyFirstMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Nishanth", Course = "MCA" },
                new Student { Id = 2, Name = "Rahul", Course = "BCA" },
                new Student { Id = 3, Name = "Anu", Course = "B.Tech" }
            };

            return Ok(students);
        }
    }
}