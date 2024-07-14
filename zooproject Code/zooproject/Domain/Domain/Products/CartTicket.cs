using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Products
{
    public class CartTicket
    {
        public Ticket Ticket;
        public int Amount { get; set; }
        public CartTicket(Ticket ticket)
        {
            Amount = 1;
            Ticket = ticket;
        }
		public CartTicket(Ticket ticket, int amount)
		{
			Amount = amount;
			Ticket = ticket;
		}
	}
}
