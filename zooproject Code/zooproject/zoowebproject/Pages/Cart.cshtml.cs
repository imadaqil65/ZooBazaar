using Domain.Domain.Cart;
using Domain.Domain.Products;
using Infrastructure.Databases.Orders;
using Infrastructure.Databases.Products;
using Logic.Services.Cart;
using Logic.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;

namespace zoowebproject.Pages
{
    public class CartModel : PageModel
    {
		public string CookieRead;
		public string CookieAmmount;

		private readonly ILogger<CartModel> _logger;
		public List<CartClass> CartClasses { get; set; }
		public Ticket Ticket { get; set; }
		CartManager cartManager;
		public List<Ticket> TicketList { get; set; }
		TicketManager ticketManager;
		public List<CartTicket> CartTicketList { get; set; }
		public CartModel(ILogger<CartModel> logger)
		{
			_logger = logger;
			cartManager = new CartManager(new DbOrder());
			CartClasses = new List<CartClass>();
			ticketManager = new TicketManager(new DBTicket());
			TicketList = ticketManager.GetTickets();
			CartTicketList = new List<CartTicket>();
		}
		public void GetTicketsFromCookie()
		{
			CookieRead = HttpUtility.UrlDecode(Request.Cookies["Cart"]);
			if (CookieRead != null)
			{
				var CookieSplit = CookieRead.Split(":");
				CookieAmmount = CookieSplit[1];

				foreach (var tickets in CookieSplit)
				{
					var Splitted = tickets.Split(",");

					foreach (var ticket in TicketList)
					{
						if (Splitted[0] != "")
						{
							if (Convert.ToInt32(Splitted[0]) == ticket.id)
							{
								var savedTicket = CartTicketList.FindIndex(x => x.Ticket.id == ticket.id);

								if (savedTicket < 0)
								{
									CartTicketList.Add(new CartTicket(ticket));
								}
								else
								{
									CartTicketList[savedTicket] = new CartTicket(ticket, CartTicketList[savedTicket].Amount += 1);
								}
							}
						}
					}
				}
			}
		}
		public void OnGet()
        {
			GetTicketsFromCookie();
		}
		public void OnPost()
		{
			GetTicketsFromCookie();
			cartManager.OrderTicket(CartTicketList);
			
			Response.Cookies.Delete("Cart");
		}

		public IActionResult OnPostReset()
		{
			// Clear the ModelState
			ModelState.Clear();

			// Return appropriate response
			return Page();
		}
	}
}
