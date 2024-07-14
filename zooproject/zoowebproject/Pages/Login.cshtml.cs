using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Security;
using zooproject.Logic.Services.User;
using zooproject.Infrastructure.Databases.Employees;
using Microsoft.AspNetCore.Identity;
using zooproject.Infrastructure.Databases.Visitors;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace zoowebproject.Pages
{
    public class LoginModel : PageModel
    {
        public string PageTitle { get; set; }
        public string Msg { get; set; }
        [BindProperty]
        [Required]
        public string username { get; set; }
        [BindProperty]
        [Required]
        public string password { get; set; }
        public int ID { get; set; }
        public EmployeeManager employeeManager { get; set; }
        public VisitorManager visitorManager { get; set; }

        public LoginModel()
        {
            employeeManager = new EmployeeManager(new DBEmployees());
            visitorManager = new VisitorManager(new DBVisitor());
        }
        public void OnGet()
        {
            PageTitle = "Login";
            Msg = string.Empty;
        }
        public IActionResult OnPost(string? returnUrl)
        {
            /*try
            {
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
            }*/

            if (ModelState.IsValid)
            {
                foreach (var visitor in visitorManager.GetVisitor())
                {
                    if (username == visitor.Username)
                    {
                        ID = visitor.Id;
                    }
                }

                if (ID == 0)
                {
                    Msg = "Incorrect credentials";
                    return Page();
                }

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim("id", ID.ToString()));
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimIdentity));

                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToPage("Index");
            }
            else
            {
                Msg = "Form not sent please try again.";
                return Page();
            }
        }
    }
}
