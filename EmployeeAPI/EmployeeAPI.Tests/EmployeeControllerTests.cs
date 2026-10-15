using EmployeeAPI.Controllers;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Tests
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void GetEmployees_ShouldReturnEmployees()
        {
            // Arrange
            EmployeeController controller = new EmployeeController();

            // Act
            var result = controller.GetEmployees();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var employees = Assert.IsType<List<Employee>>(okResult.Value);

            Assert.Equal(2, employees.Count);
        }
    }
}