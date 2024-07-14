using zooproject.Domain.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using Infrastructure.Databases.Orders;
using Newtonsoft.Json;
using Domain.Domain.Country;
using zooproject.Domain.Domain.Cart;
using SkiaSharp;
using BarcodeStandard;
using System.Drawing;

namespace Logic.Services.Cart
{
	public class OrderManager
	{
		IDbOrder datasource;
		public CartClass Cart { get; set; }
		public List<SKImage> images;

		public OrderManager(IDbOrder source)
		{
			Cart = new CartClass();
			datasource = source;
		}

        public void AddTicketsToCartAmount(Ticket ticket, int amount)
        {
            Cart.cartTickets.Add(new CartTicket(ticket, amount));
        }

		public List<CartTicket> GetCartTicketList()
		{
			return Cart.cartTickets.ToList();
		}

		public void OrderTicket(List<CartTicket> ticket, string email, Country country, string adress)
		{
			List<CartTicket> cartTicketList = new List<CartTicket>();
			
			if (ticket.Count() < 1)
			{
				return;
			}

			foreach (var c in ticket)
			{
				for (int i = 0; i < c.Amount; i++)
				{
					cartTicketList.Add(new CartTicket(c.Ticket,i));
				}
			}

			datasource.OrderTicket(cartTicketList, email, country, adress);
		}

		public List<string> IdAmountSeparator(string[] ids, string[] amounts)
		{
			List<string> IdAndAmount = new List<string>();

            for (int i = 0; i < ids.Length; i++)
			{
				IdAndAmount.Add(ids[i] + "," + amounts[i]);
			}

			return IdAndAmount;
		}

		public List<CartTicket> CartAddProcess(List<string>IdAndAmount, List<Ticket>TicketList, string JsonList)
		{
            var newCartTicketList = new List<CartTicket>();
            foreach (var i in IdAndAmount)
            {
                string[] IdAmountGet = i.Split(',');
                int Id = Convert.ToInt32(IdAmountGet[0]);
                int amount = Convert.ToInt32(IdAmountGet[1]);


                Ticket ticket = TicketList.FirstOrDefault(t => t.id == Id);
                if (JsonList != null)
                {
                    var cartTicketList = JsonConvert.DeserializeObject<List<CartTicket>>(JsonList);
                    var existingCartTicket = cartTicketList.FirstOrDefault(x => x.Ticket.id == Id);
                    if (existingCartTicket != null)
                    {
                        amount = existingCartTicket.Amount + amount;
                    }
                }

                if (amount > 0)
                {
                    var newCartTicket = new CartTicket {Ticket = ticket, Amount = amount };
                    newCartTicketList.Add(newCartTicket);
                }
            }
			return newCartTicketList;
        }

		public List<Ticket> GetTicketsOfGivenWeek(DateTime dateA, DateTime dateB)
		{
			return datasource.GetOrderedTicketsByDate(dateA, dateB);
		}

		public List<long> TicketBarcodes(string email)
		{
			return datasource.GetTicketsBarcode(email);
		}

		public List<SKImage> TicketGetter(string something)
		{
			List<SKImage> result = new List<SKImage>();

			foreach (var bar in datasource.GetTicketsBarcode(something))
			{
				Barcode barcode = new Barcode();
				SKColor foreColor = SKColors.Black;
				SKColor backColor = SKColors.Transparent;
				SKImage img = barcode.Encode(BarcodeStandard.Type.Code128, $"{bar}");
				result.Add(img);
			}

			return result;
		}

		public bool MakeTicketUsed(long barcode)
		{
			return datasource.MakeTicketUsed(barcode);
		}

		public void SetTicketToUsed()
		{

		}
	}
}
