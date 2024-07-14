using Domain.Domain.Cart;
using Domain.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using Infrastructure.Databases.Orders;

namespace Logic.Services.Cart
{
	public class CartManager
	{
		IDbOrder datasource;
		public CartClass Cart { get; set; }

		public CartManager(IDbOrder source)
		{
			Cart = new CartClass();
			datasource = source;
		}

		public void AddTicketsToCart(Ticket ticket)
		{
			Cart.cartTickets.Add(new CartTicket(ticket));
		}

		public string TicketToString()
		{
			string tickets = "";
			foreach(var ticket in Cart.cartTickets)
            {
                tickets += $"{ ticket.Ticket.id},{ ticket.Amount}:";
            }
            return tickets;
        }

        /*		public void RemoveTicketsFromCart(Ticket ticket)
                {
                    Cart.cartTickets.Remove(new CartTicket(ticket));
                }*/
		public void OrderTicket(List<CartTicket> ticket)
		{
			if (ticket.Count() < 1)
			{
				return;
			}
			datasource.OrderTicket(ticket);
		}
	}
}
