using Domain.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Cart
{
	public class CartClass
	{
		public List<CartTicket> cartTickets {  get; set; }
		public CartClass()
		{
			cartTickets = new List<CartTicket>();
		}
	}
}
