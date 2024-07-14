using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zooproject.Domain.Domain.User;
using zooproject.Logic.Services.User;
using zooproject.Infrastructure.Databases.Visitors;
using zooproject.Domain.Domain.Security;
using Domain.Domain.Country;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace zoowebproject.Pages
{
    public class RegisterModel : PageModel
    {
        public string PageTitle { get; set; }
        public string Message { get; set; }
        public VisitorManager visitorManager { get; set; }

        [BindProperty]
        public Visitor newUser { get; set; }
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

                if (visitorManager.EmailCheck(newUser.Email))
                {
                    Message = "Email already exist";
                    return Page();
                }

                string pass = newUser.Password;
                pass = Hash.HashPassword(pass);
                newUser.Password = pass;
                visitorManager.CreateVisitor(newUser);

				return RedirectToPage("RegisterSuccess");
            }
            return Page();
        }

		public List<SelectListItem> GetCountrySelectList()
		{
			var countryValues = Enum.GetValues(typeof(Country)).Cast<Country>();
			var selectListItems = countryValues.Select(country => new SelectListItem
			{
				Value = country.ToString(),
				Text = country.ToString().Replace("_", " ")
			}).ToList();

			return selectListItems;
		}
	}
}
