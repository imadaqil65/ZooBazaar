using Domain.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Databases.Orders
{
	public interface IDbOrder
	{
		public void OrderTicket(List<CartTicket> cartTickets);
	}
}
