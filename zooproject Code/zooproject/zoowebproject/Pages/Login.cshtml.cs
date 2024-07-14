using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Security;
using zooproject.Logic.Services.User;
using zooproject.Infrastructure.Databases.Employees;
using Microsoft.AspNetCore.Identity;

namespace zoowebproject.Pages
{
    public class LoginModel : PageModel
    {
        public string PageTitle { get; set; }
        public string Msg { get; set; }

        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }
        [BindProperty]
        public int ID { get; set; }
        EmployeeManager employeeManager { get; set; }
        public void OnGet()
        {
            PageTitle = "Login";
            Msg = string.Empty;
            employeeManager = new EmployeeManager(new DBEmployees()); 
        }
        public IActionResult OnPost()
        {
            try
            {
                employeeManager = new EmployeeManager(new DBEmployees());
                Msg = string.Empty;
                if (employeeManager.CheckUsername(username) == true && Hash.VerifyHashedPassword(employeeManager.GetHashByUserName(username), password) == true)
                {
                    ID = employeeManager.GetID(username);
                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetInt32("userid", ID);
                    return RedirectToPage("Storepage");
                }
                else
                {
                    Msg = "Form not sent please try again.";
                    return Page();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Msg = Ex.Message;
                return Page();
            }
        }
    }
}
