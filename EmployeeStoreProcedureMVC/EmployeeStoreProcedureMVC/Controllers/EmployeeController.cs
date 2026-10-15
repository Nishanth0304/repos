using EmployeeStoreProcedureMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EmployeeStoreProcedureMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();

            string connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "GetAllEmployees",
                    connection);

                command.CommandType =
                    System.Data.CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee();

                    employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    employee.Name = reader["Name"].ToString();
                    employee.Department = reader["Department"].ToString();
                    employee.Salary = Convert.ToDecimal(reader["Salary"]);

                    employees.Add(employee);
                }
            }

            return View(employees);
        }
    }
}
