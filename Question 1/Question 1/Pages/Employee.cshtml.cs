using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagementSystem.Pages
{
    public class EmployeeModel : PageModel
    {
        [BindProperty]
        public EmployeeInput Employee { get; set; }

        public bool Submitted { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Submitted = true;
            return Page();
        }

        public class EmployeeInput
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }
        }
    }
}
