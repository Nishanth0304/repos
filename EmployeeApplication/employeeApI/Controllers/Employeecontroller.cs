using Microsoft.AspNetCore.Mvc;
using employeeAPI.Models;

namespace employeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Nishanth",
                Email = "Nishanth@gmail.com",
                Department = "IT",
                Salary = 60000
            },
            new Employee
            {
                Id = 2,
                Name = "Vivek",
                Email = "vivek@gmail.com",
                Department = "HR",
                Salary = 50000
            }
        };

        // GET: api/Employee
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        // GET: api/Employee/1
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            employee.Id = employees.Count + 1;

            employees.Add(employee);

            return CreatedAtAction(
                nameof(GetEmployee),
                new { id = employee.Id },
                employee
            );
        }

        // PUT: api/Employee/1
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;

            return Ok(existingEmployee);
        }

        // DELETE: api/Employee/1
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            employees.Remove(employee);

            return Ok(employee);
        }
    }
}