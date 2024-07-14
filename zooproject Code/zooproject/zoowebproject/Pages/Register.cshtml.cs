using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zooproject.Domain.Domain.User;
using zooproject.Logic.Services.User;
using zooproject.Infrastructure.Databases.Visitors;
using zooproject.Domain.Domain.Security;

namespace zoowebproject.Pages
{
    public class RegisterModel : PageModel
    {
        public string PageTitle { get; set; }
        public string Message { get; set; }
        public VisitorManager visitorManager { get; set; }

        [BindProperty]
        public User newUser { get; set; }
        public void OnGet()
        {
            PageTitle = "Register";
            newUser = new Visitor();
        }
        public IActionResult OnPost()
        {
            Message = string.Empty;
            if (ModelState.IsValid)
            {
                visitorManager = new VisitorManager(new DBVisitor());
                string pass = newUser.Password;
                pass = Hash.HashPassword(pass);
                newUser.Password = pass;
                //employeeManager.CreateEmployee(newUser);
                
                //We still need to flesh out the visitor side of the classes!
            }
            return Page();
        }
    }
}
