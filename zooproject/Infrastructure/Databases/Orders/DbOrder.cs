using zooproject.Domain.Domain.Products;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;
using Domain.Domain.Country;
using zooproject.Domain.Domain.Cart;

namespace Infrastructure.Databases.Orders
{
	public class DbOrder :IDbOrder
	{
		public MySqlConnection GetConnection()
		{
			MySqlConnection conn =
				new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
			return conn;
		}

		public void OrderTicket(List<CartTicket> cartTickets, string email, Country country, string address)
		{
			string commandOrder = "INSERT INTO `zb_order`(`buyer_email`,`Country`,`Adress`) VALUES (@BuyerEmail,@BuyerCountry,@BuyerAdress) ; SELECT LAST_INSERT_ID();";
			string commandLine = "INSERT INTO `zb_order_lines`(`order_id`,`ticket_id`,`Amount_nr`,`Purchased_Date`, `Used_date`, `Barcode`) VALUES (@Order_Id, @ProductId, @AmountNr, @BuyerPurchaseDate, @UsedDate, @Barcode)";

			MySqlConnection conn = GetConnection();
			MySqlCommand addOrder = new MySqlCommand(commandOrder, conn);
			MySqlCommand addLine = new MySqlCommand(commandLine, conn);

			try
			{
				conn.Open();
				addOrder.Parameters.AddWithValue("@BuyerEmail", email);
				addOrder.Parameters.AddWithValue("@BuyerCountry", country);
				addOrder.Parameters.AddWithValue("@BuyerAdress", address);
				var orderId = Convert.ToInt32(addOrder.ExecuteScalar());

				foreach (CartTicket cartTicket in cartTickets)
				{
					// Generate barcode
					long barcode = GenerateBarcodedTicket(orderId, cartTicket);

					addLine.Parameters.AddWithValue("@Order_Id", orderId);
					addLine.Parameters.AddWithValue("@ProductId", cartTicket.Ticket.id);
					addLine.Parameters.AddWithValue("@BuyerPurchaseDate", DateTime.Now);
					addLine.Parameters.AddWithValue("@AmountNr", cartTicket.Amount);
					addLine.Parameters.AddWithValue("@UsedDate", DateTime.Parse("1000-01-01")); // Update with appropriate value
					addLine.Parameters.AddWithValue("@Barcode", barcode);
					addLine.ExecuteNonQuery();
					addLine.Parameters.Clear();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conn.Close();
			}
		}

		public long GenerateBarcodedTicket(int orderId, CartTicket cartTicket)
		{
			int ticketId = cartTicket.Ticket.id;
			int ticketPosition = cartTicket.Amount;
			DateTime purchasedDate = DateTime.Now;
			int dateConvert = purchasedDate.Year * 10000 + purchasedDate.Month * 100 + purchasedDate.Day;
			int amount = cartTicket.Amount;

			string barcode = $"{orderId}{ticketId}{amount}{ticketPosition}{dateConvert}";

			return Convert.ToInt64(barcode);
		}

		public List<CartClass> GetOrderedTickets()
		{
			List<CartClass> cartClassList = new List<CartClass>();
			string sqlGetOrders = "SELECT * FROM zb_order AS o INNER JOIN zb_order_lines AS o_line ON o.order_id = o_line.order_id INNER JOIN zb_tickets AS t ON o_line.ticket_id = t.id";

			using (MySqlConnection conn = GetConnection())
			{
				MySqlCommand getOrder = new MySqlCommand(sqlGetOrders, conn);

				try
				{
					conn.Open();
					using (MySqlDataReader reader = getOrder.ExecuteReader())
					{
						while (reader.Read())
						{
							int ticketId = reader.GetInt32("ticket_id");
							string ticketName = reader.GetString("name");
							int price = reader.GetInt32("price");
							string description = reader.GetString("description");
							DateTime purchasedDate = reader.GetDateTime("Purchased_date");
							/*int amount = reader.GetInt32("amount");*/

							Ticket ticket = new Ticket(ticketId, ticketName, price, description);
/*							CartTicket cartTicket = new CartTicket(ticket, amount);
*/							CartTicket cartTicket = new CartTicket(ticket);

							CartClass cartClass = new CartClass();
							cartClass.cartTickets.Add(cartTicket);
							cartClass.PurchasedDate = purchasedDate;

							cartClassList.Add(cartClass);
						}
					}
				}
				// TODO: Work on proper exceptions handling
				catch (Exception ex)
				{
					throw ex;
				}
			}

			return cartClassList;
		}


		public List<long> GetTicketsBarcode(string email)
		{
			List<long> barcode = new List<long>();
			string sqlGetOrders = @"SELECT o_line.Barcode
                        FROM zb_order_lines AS o_line
                        INNER JOIN zb_order AS o ON o_line.order_id = o.order_id
                        WHERE o_line.order_id = (
                            SELECT order_id
                            FROM zb_order
                            WHERE buyer_email = @email
                            ORDER BY order_id DESC
                            LIMIT 1
                        )";

			using (MySqlConnection conn = GetConnection())
			{
				MySqlCommand getOrder = new MySqlCommand(sqlGetOrders, conn);
				getOrder.Parameters.AddWithValue("@email", email);

				try
				{
					conn.Open();
					using (MySqlDataReader reader = getOrder.ExecuteReader())
					{
						while (reader.Read())
						{
							long ticketBarcode = reader.GetInt64("Barcode");
							barcode.Add(ticketBarcode);
						}
					}
				}
				// TODO: Work on proper exceptions handling
				catch (Exception ex)
				{
					throw ex;
				}
			}

			return barcode;
		}


		public bool MakeTicketUsed(long barcode)
		{
			bool used = false;
			string sqlUpdateOrders = @"UPDATE zb_order_lines 
                               SET Used_date = @date
                               WHERE Barcode = @barcode AND Used_date = '1000-01-01 00:00:00'";

			using (MySqlConnection conn = GetConnection())
			{
				MySqlCommand updateOrder = new MySqlCommand(sqlUpdateOrders, conn);
				updateOrder.Parameters.AddWithValue("@barcode", barcode);
				updateOrder.Parameters.AddWithValue("@date", DateTime.Now);

				try
				{
					conn.Open();
					int rowsAffected = updateOrder.ExecuteNonQuery();
					used = rowsAffected > 0;
				}
				catch (Exception ex)
				{

				}
				finally
				{
					conn.Close();
				}
			}

			return used;
		}






		public List<Ticket> GetOrderedTicketsByDate(DateTime dateA, DateTime dateB)
		{
			/*List<CartClass> cartClassList = new List<CartClass>();*/
			List<Ticket> ticketList = new List<Ticket>();
			string sqlGetOrders = "SELECT * FROM zb_order AS o INNER JOIN zb_order_lines AS o_line ON o.order_id = o_line.order_id INNER JOIN zb_tickets AS t ON o_line.ticket_id = t.ticket_id WHERE o_line.purchased_date >= @DateA AND o_line.purchased_date <= @DateB";

			using (MySqlConnection conn = GetConnection())
			{
				MySqlCommand getOrder = new MySqlCommand(sqlGetOrders, conn);
				getOrder.Parameters.AddWithValue("@DateA", dateA);
				getOrder.Parameters.AddWithValue("@DateB", dateB);

				try
				{
					conn.Open();
					using (MySqlDataReader reader = getOrder.ExecuteReader())
					{
						while (reader.Read())
						{
							int ticketId = reader.GetInt32("ticket_id");
							string ticketName = reader.GetString("name");
							int price = reader.GetInt32("price");
							string description = reader.GetString("description");
							DateTime purchasedDate = reader.GetDateTime("Purchased_date");
							DateTime usedDate = DateTime.Parse(reader.GetString("Used_date"));

							Ticket ticket = new Ticket(ticketId, ticketName, price, description, purchasedDate, usedDate);
							ticketList.Add(ticket);
						}
					}
				}
				// TODO: Work on proper exceptions handling
				catch (Exception ex)
				{
					throw ex;
				}
			}

			return ticketList;
		}

		/*public List<Ticket> GetOrderedTicketsByDate(DateTime dateA, DateTime dateB)
		{
			*//*List<CartClass> cartClassList = new List<CartClass>();*//*
			List<Ticket> ticketList = new List<Ticket>();
			string sqlGetOrders = "SELECT * FROM zb_order AS o INNER JOIN zb_order_lines AS o_line ON o.order_id = o_line.order_id INNER JOIN zb_tickets AS t ON o_line.ticket_id = t.ticket_id WHERE o_line.purchased_date >= @DateA AND o_line.purchased_date <= @DateB";

			using (MySqlConnection conn = GetConnection())
			{
				MySqlCommand getOrder = new MySqlCommand(sqlGetOrders, conn);
				getOrder.Parameters.AddWithValue("@DateA", dateA);
				getOrder.Parameters.AddWithValue("@DateB", dateB);

				try
				{
					conn.Open();
					using (MySqlDataReader reader = getOrder.ExecuteReader())
					{
						while (reader.Read())
						{
							int ticketId = reader.GetInt32("ticket_id");
							string ticketName = reader.GetString("name");
							int price = reader.GetInt32("price");
							string description = reader.GetString("description");
							DateTime purchasedDate = reader.GetDateTime("Purchased_date");
							DateTime usedDate = DateTime.Parse(reader.GetString("Used_date"));
							*//*int amount = reader.GetInt32("amount");*//*

							Ticket ticket = new Ticket(ticketId, ticketName, price, description, purchasedDate, usedDate);
							ticketList.Add(ticket);
							*//*CartTicket cartTicket = new CartTicket(ticket, amount);*/
							/*							CartTicket cartTicket = new CartTicket(ticket);

														CartClass cartClass = new CartClass();
														cartClass.cartTickets = new List<CartTicket>();
														cartClass.cartTickets.Add(cartTicket);
														cartClass.PurchasedDate = purchasedDate;
														cartClass.UsedDate = usedDate;
														cartClassList.Add(cartClass);*//*
						}
					}
				}
				// TODO: Work on proper exceptions handling
				catch (Exception ex)
				{
					throw ex;
				}
			}

			return ticketList;
		}*/




	}
}
