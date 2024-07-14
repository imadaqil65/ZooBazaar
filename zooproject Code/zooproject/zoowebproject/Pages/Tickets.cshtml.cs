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
    public class TicketsModel : PageModel
    {
        public string PageTitle { get; private set; }
        TicketManager ticketManager;
        public List<Ticket> TicketList = new List<Ticket> { };
        public Ticket Ticket { get; set; }

        public List<Ticket> CartList = new List<Ticket> { };

        public string cart = "Cart";

        public CartManager CartManager { get; private set; }

        CookieOptions CartCookie;

		public TicketsModel()
        {
            PageTitle = "Tickets Page";
            CartManager = new CartManager(new DbOrder());
            CartCookie = new CookieOptions();
			CartCookie.Expires = DateTime.Now.AddDays(7);
            ticketManager = new TicketManager(new DBTicket());
            TicketList = ticketManager.GetTickets();
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var id = Request.Form["Id"];
/*            var ammount = Request.Form[];*/
            foreach(var ticket in TicketList)
            {
                if(Convert.ToInt32(id) == ticket.id)
                {
                    Ticket = ticket;
                }
            }

/*            HttpContext.Session.SetString("Cart", cart);*/
            CartManager.AddTicketsToCart(Ticket);
            if (Request.Cookies["Cart"] == null)
            {
				Response.Cookies.Append("Cart", HttpUtility.UrlEncode(CartManager.TicketToString()), CartCookie);
			}
            else
            {
                Response.Cookies.Append("Cart", Request.Cookies["Cart"] + HttpUtility.UrlEncode(CartManager.TicketToString()), CartCookie);
            }
            return RedirectToPage("Cart");
        }
    }
}
