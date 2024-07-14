using zooproject.Domain.Domain.Products;
using Infrastructure.Databases.Products;
using Logic.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zoowebproject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string CartFromCookie;

        public IndexModel(ILogger<IndexModel> logger)
        {
/*            PageTitle = "Home Page";*/
            _logger = logger;
        }

/*        public string PageTitle { get; private set; }*/
/*        TicketManager ticketManager;
        public List<Ticket> TicketList = new List<Ticket> { };
        public Ticket ticket;
        int id = 1;*/
        public void OnGet()
        {
/*            ticketManager = new TicketManager(new DBTicket());
            ticket = ticketManager.GetTicket(id);
            CartFromCookie = Request.Cookies["Cart"];*/
        }
    }
}