using zooproject.Domain.Domain.Products;
using Infrastructure.Databases.Orders;
using Infrastructure.Databases.Products;
using Logic.Services.Cart;
using Logic.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json.Serialization;
using System.Web;
using zooproject.Domain.Domain.User;
using zooproject.Infrastructure.Databases.Visitors;
using zooproject.Logic.Services.User;
using Domain.Domain.Country;
using Microsoft.AspNetCore.Mvc.Rendering;
using Logic.Services.EmailService;
using Infrastructure.Email;
using SkiaSharp;

namespace zoowebproject.Pages
{
    public class TicketsModel : PageModel
    {
        public int TotalPrice { get; set; }
        public string PageTitle { get; private set; }
        TicketManager ticketManager;
        public List<Ticket> TicketList = new List<Ticket> { };
        public Ticket Ticket { get; set; }
        public List<CartTicket> CartTicketList { get; set; }
        public OrderManager OrderManager { get; private set; }
        private CookieOptions CartCookie { get; set; }
        private Visitor SelectedUser { get; set; }
        private VisitorManager visitorManager { get; set; }
        private EmailManager emailManager { get; set; }
        public string Msg { get; set; }

        public TicketsModel()
        {
            PageTitle = "Tickets Page";
            OrderManager = new OrderManager(new DbOrder());
            CartCookie = new CookieOptions();
            CartCookie.Expires = DateTime.Now.AddDays(7);
            ticketManager = new TicketManager(new DBTicket());
            TicketList = ticketManager.GetTickets();
            CartTicketList = new List<CartTicket>();
            visitorManager = new VisitorManager(new DBVisitor());
            emailManager = new EmailManager(new dbEmail());
        }
        public void OnGet()
        {
            JsonReuse();
            int totalPrice = 0;
            foreach (var ticket in CartTicketList)
            {
                totalPrice += ticket.Amount * ticket.Ticket.price;
            }
            TotalPrice = totalPrice;
        }

        public void GetLoggedInUser()
        {
            var userIdClaim = User.FindFirst("id");

            if (userIdClaim == null)
            {
                return;
            }

            int userId = int.Parse(userIdClaim.Value);

            SelectedUser = visitorManager.GetVisitorById(userId);
        }

        public void JsonReuse()
        {
            int totalPrice = HttpContext.Session.GetInt32("TotalPrice")??0;
            
            string cartTicketListJson = HttpContext.Session.GetString("CartTicketList");
            if (!string.IsNullOrEmpty(cartTicketListJson))
            {
                List<CartTicket> cartTicketList = JsonConvert.DeserializeObject<List<CartTicket>>(cartTicketListJson);
                CartTicketList = cartTicketList;
                TotalPrice = totalPrice;
            }
        }

        public IActionResult OnPostDecreaseAmount(int id)
        {
            var cartTicket = CartTicketList.FirstOrDefault(t => t.Ticket.id == id);
            if (cartTicket != null)
            {
                if (cartTicket.Amount > 1)
                {
                    cartTicket.Amount-=1;
                    HttpContext.Session.SetString("CartTicketList", JsonConvert.SerializeObject(CartTicketList));
                    return Page();
                }
                CartTicketList.Remove(cartTicket);
                HttpContext.Session.SetString("CartTicketList", JsonConvert.SerializeObject(CartTicketList));
                return Page();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Request.Form["action"] == "addtocart")
            {
                string[] ids = Request.Form["Id"];
                string[] amounts = Request.Form["Amount"];

                List<string> IdAndAmount = OrderManager.IdAmountSeparator(ids, amounts);

                int total = 0;

                string cartTicketListJson = HttpContext.Session.GetString("CartTicketList");
                var newCartTicketList = OrderManager.CartAddProcess(IdAndAmount, TicketList, cartTicketListJson);

                foreach (var price in newCartTicketList)
                {
                    total += price.Ticket.price * price.Amount;
                }

                TotalPrice = total;
                CartTicketList = newCartTicketList;
                string serializedTicketList = JsonConvert.SerializeObject(newCartTicketList);
                HttpContext.Session.SetString("CartTicketList", serializedTicketList);
                HttpContext.Session.SetInt32("TotalPrice", TotalPrice);

                return RedirectToPage("Tickets");
            }

            if (Request.Form["reset"] == "Reset")
            {
                HttpContext.Session.Clear();
                ModelState.Clear();
                return new RedirectResult("Tickets");
            }

            if (Request.Form.TryGetValue("removeTicket", out var removeTicketId))
            {
                return OnPostRemove(removeTicketId);
            }

            if (Request.Form.TryGetValue("decreaseSelected", out var decreaseSelectedId))
            {
                return OnPostDecrease(decreaseSelectedId);
            }

            string email = "";
			Country selectedCountry = Country.Unknown;
			string adress = "";

            if (Request.Form["checkout"] == "Checkout")
            {
                JsonReuse();
                GetLoggedInUser();
                if (CartTicketList.Count == 0)
                {
                    Msg = "Please add a ticket to the cart";
                    return RedirectToPage();
                }
                if (SelectedUser == null)
                {
                    email = Request.Form["email"];

					if (Enum.TryParse(Request.Form["country"], out Country parsedCountry))
					{
						selectedCountry = parsedCountry;
					}
					adress = Request.Form["adress"];
                }
                else
                {
                    OrderManager.OrderTicket(CartTicketList, SelectedUser.Email, SelectedUser.Country, SelectedUser.Adress);
                    HttpContext.Session.Clear();
                    ModelState.Clear();
					List<SKImage> barcodes = OrderManager.TicketGetter(SelectedUser.Email);
					foreach (SKImage barcode in barcodes)
					{
						using (MemoryStream ms = new MemoryStream())
						{
							barcode.Encode(SKEncodedImageFormat.Png, 100).SaveTo(ms);
							ms.Position = 0;
							emailManager.AddAttachment(ms, "barcode.png");
						}
					}
					emailManager.SendEmail(email, "Ticket", $"Heres your ticket/s in the attachements");

					return RedirectToPage("PurchaseSuccess", new { message = "Purchase successful" });
                }
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(adress) || selectedCountry.Equals(Country.Unknown))
                {
                    Msg = "Please fill in all the fields";
                    return Page();
                }
                else
                {
                    OrderManager.OrderTicket(CartTicketList, email, selectedCountry, adress);
                    HttpContext.Session.Clear();
                    ModelState.Clear();
                    /*List<long> barcodes = OrderManager.TicketBarcodes(email);*/
                    List<SKImage> barcodes = OrderManager.TicketGetter(email);
					foreach (SKImage barcode in barcodes)
					{
						using (MemoryStream ms = new MemoryStream())
						{
							barcode.Encode(SKEncodedImageFormat.Png, 100).SaveTo(ms);
							ms.Position = 0;
							emailManager.AddAttachment(ms, "barcode.png");
						}
					}
					string barcodeString = string.Join(", ", barcodes);
					emailManager.SendEmail(email, "Ticket", $"Heres your ticket/s in the attachements");

					return RedirectToPage("PurchaseSuccess", new { message = "Purchase successful" });
                }
            }
            else
            {
                OnGet();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostRemove(string ticketId)
        {
            int id = Convert.ToInt32(ticketId);
            JsonReuse();

            int removedPrice = TotalPrice;
            foreach (var ticket in CartTicketList)
            {
                if (id == ticket.Ticket.id)
                {
                    removedPrice = ticket.Ticket.price * ticket.Amount;
                    CartTicketList.Remove(ticket);
                    break;
                }
            }

            TotalPrice -= removedPrice;
            string cartTicketListJson = JsonConvert.SerializeObject(CartTicketList);
            HttpContext.Session.SetString("CartTicketList", cartTicketListJson);
            HttpContext.Session.SetInt32("TotalPrice", TotalPrice);

            return RedirectToPage();
        }

        public IActionResult OnPostDecrease(string decreaseSelectedId)
        {
            int id = Convert.ToInt32(decreaseSelectedId);

            JsonReuse();
            int removedPrice = TotalPrice;

            foreach (var ticket in CartTicketList)
            {
                if (id == ticket.Ticket.id && ticket.Amount == 1)
                {
                    removedPrice = ticket.Ticket.price;
                    CartTicketList.Remove(ticket);
                    break;
                }
                if (id == ticket.Ticket.id && ticket.Amount > 1)
                {
                    ticket.Amount -= 1;
                    removedPrice = ticket.Ticket.price;
                    int index = CartTicketList.IndexOf(ticket);
                    CartTicketList[index] = ticket;
                    break;
                }
            }

            TotalPrice -= removedPrice;
            string cartTicketListJson = JsonConvert.SerializeObject(CartTicketList);
            HttpContext.Session.SetString("CartTicketList", cartTicketListJson);
            HttpContext.Session.SetInt32("TotalPrice", TotalPrice);
            return RedirectToPage();
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
