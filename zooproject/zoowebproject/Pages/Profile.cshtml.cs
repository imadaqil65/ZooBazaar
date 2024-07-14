using Domain.Domain.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using zooproject.Domain.Domain.Security;
using zooproject.Domain.Domain.User;
using zooproject.Infrastructure.Databases.Visitors;
using zooproject.Logic.Services.User;

namespace zoowebproject.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
		public string Msg;
		public Visitor SelectedUser { get; set; }
		private VisitorManager visitorManager { get; set; }

		public ProfileModel()
		{
			visitorManager = new VisitorManager(new DBVisitor());
		}

        public void OnGet()
        {
			GetLoggedInUser();
		}

		public void GetLoggedInUser()
		{
			var userIdClaim = User.FindFirst("id");

			int userId = int.Parse(userIdClaim.Value);

			SelectedUser = visitorManager.GetVisitorById(userId);
		}

		public IActionResult OnPost()
		{
			GetLoggedInUser();
			if (Request.Form["delete"] == "Delete")
			{
				visitorManager.RemoveVisitor(SelectedUser);
				return RedirectToPage("LogoutPage");
			}

			if (Request.Form["save"] == "Save")
			{
				string firstName = Request.Form["firstName"];
				string lastName = Request.Form["lastName"];
				string username = Request.Form["username"];
				string email = Request.Form["email"];
				string password = Request.Form["password"];
				string adress = Request.Form["adress"];
				string country = Request.Form["country"];

				if (firstName == "" || lastName == "" || username == "" || email == "" || adress == "")
				{
					Msg = "One of the fields is empty";
					return Page();
				}
				Visitor updatedUser = visitorManager.GetVisitorById(SelectedUser.Id);
				if (!string.IsNullOrEmpty(password))
				{
					updatedUser.FirstName = firstName;
					updatedUser.LastName = lastName;
					updatedUser.Username = username;
					updatedUser.Email = email;
					updatedUser.Password = Hash.HashPassword(password);
				}
				else
				{
					updatedUser.FirstName = firstName;
					updatedUser.LastName = lastName;
					updatedUser.Username = username;
					updatedUser.Email = email;
					updatedUser.Adress = adress;
					if (Enum.TryParse(typeof(Country), country, out object parsedValue))
					{
						updatedUser.Country = (Country)parsedValue;
					}
				}
				visitorManager.EditVisitor(updatedUser);
				Msg = "update Successfull";
				return Page();
			}

			return Page();
		}

		public List<SelectListItem> GetCountrySelectList()
		{
			var countryValues = Enum.GetValues(typeof(Country)).Cast<Country>();
			var selectListItems = countryValues.Select(country => new SelectListItem
			{
				Value = country.ToString(),
				Text = country.ToString().Replace("_", " "),
				Selected = country == SelectedUser.Country
			}).ToList();

			return selectListItems;
		}

	}
}
