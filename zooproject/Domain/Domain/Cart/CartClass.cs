using zooproject.Domain.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zooproject.Domain.Domain.Cart
{
	public class CartClass
	{
		public List<CartTicket> cartTickets {  get; set; }
		public DateTime PurchasedDate { get; set; }
		public DateTime UsedDate { get; set; }
		public CartClass() { }
		public CartClass(DateTime purchasedDate, DateTime usedDate)
		{
			cartTickets = new List<CartTicket>();
			PurchasedDate = purchasedDate;
			UsedDate = usedDate;
		}
		public CartClass(List<CartTicket> cart, DateTime purchasedDate, DateTime usedDate)
		{
			cartTickets = new List<CartTicket>();
			PurchasedDate = purchasedDate;
			UsedDate = usedDate;
		}

		public CartClass(List<CartTicket> cart, DateTime purchasedDate)
		{
			cartTickets = new List<CartTicket>();
			PurchasedDate = purchasedDate;
		}
	}
}
