using zooproject.Domain.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Country;
using zooproject.Domain.Domain.Cart;

namespace Infrastructure.Databases.Orders
{
	public interface IDbOrder
	{
		public void OrderTicket(List<CartTicket> cartTickets, string email, Country country, string adress);
		public List<CartClass> GetOrderedTickets();
		public List<Ticket> GetOrderedTicketsByDate(DateTime dateA, DateTime dateB);
		public List<long> GetTicketsBarcode(string email);
		public bool MakeTicketUsed(long barcode);
	}
}
