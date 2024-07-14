using Domain.Domain.Products;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;

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

		public void OrderTicket(List<CartTicket> cartTickets)
		{
			string commandOrder = "INSERT INTO `zb_order`(`buyer_fullname`) VALUES (@BuyerFullName) ; SELECT LAST_INSERT_ID();";

			string commandLine = "INSERT INTO `zb_order_lines`(`order_id`,`ticket_id`, `amount`) VALUES (@Order_Id, @ProductId, @Amount)";

			MySqlConnection conn = GetConnection();
			MySqlCommand addOrder = new MySqlCommand(commandOrder, conn);

			MySqlCommand addLine = new MySqlCommand(commandLine, conn);
			try
			{
				conn.Open();
				addOrder.Parameters.AddWithValue("@BuyerFullName", "Guest");
				var orderId = Convert.ToInt32(addOrder.ExecuteScalar());


				foreach (CartTicket cartTicket in cartTickets)
				{
					addLine.Parameters.AddWithValue("@Order_Id", orderId);
					addLine.Parameters.AddWithValue("@ProductId", cartTicket.Ticket.id);
					addLine.Parameters.AddWithValue("@Amount", cartTicket.Amount);
					addLine.ExecuteNonQuery();
					addLine.Parameters.Clear();
				}
/*				addOrder.Parameters.AddWithValue("")
				addOrder.Parameters.AddWithValue("@BuyerFullName", "Guest");*/
			}
			//TODO: work on proper exhceptions
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				conn.Close();
			}
		}

	}
}
