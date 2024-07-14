using zooproject.Domain.Domain.Products;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;

namespace Infrastructure.Databases.Products
{
    public class DBTicket : ITicket
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
            return conn;

        }
        public void AddTicket(Ticket t)
        {
            string command = "INSERT INTO `zb_tickets`(`ticket_id`, `name`, `price`, `description`, `image`) VALUES (NULL,@name,@price,@description,@image)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@name", t.name);
                add.Parameters.AddWithValue("@price", t.price);
                add.Parameters.AddWithValue("@description", t.description);
                add.Parameters.AddWithValue("@image", t.image);

                MySqlDataReader reader = add.ExecuteReader();
            }
            //TODO: work on proper exhceptions
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Ticket> ReadAllTickets()
        {
            List<Ticket> tickets = new List<Ticket>();


            string command = "SELECT * FROM `zb_tickets`";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();

                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("ticket_id");
                    string name = reader.GetString("name");
                    int price = reader.GetInt32("price") ;
                    string description = reader.GetString("description");
                    string image = reader.GetString("image");
                    tickets.Add(new Ticket(id, name, price, description, image));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }

            return tickets;
        }

        public void RemoveTicket(Ticket t)
        {
            string command = "DELETE FROM `zb_tickets` WHERE ticket_id =@ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@ID", t.id);
                MySqlDataReader reader = add.ExecuteReader();
            }
            //TODO: work on proper exhceptions
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateTicket(Ticket t)
        {
            string command = "UPDATE `zb_tickets` SET `name`=@name,`price`=@price,`description`=@description, `image`=@image WHERE id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@name", t.name);
                add.Parameters.AddWithValue("@price", t.price);
                add.Parameters.AddWithValue("@description", t.description);
                add.Parameters.AddWithValue("@image", t.image);
                add.Parameters.AddWithValue("@id", t.id);
                MySqlDataReader reader = add.ExecuteReader();
            }
            //TODO: work on proper exhceptions
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }

        public Ticket ReadTicket(int id)
        {
            Ticket selectedTicket =  null;

            string command = $"SELECT * FROM `zb_tickets` WHERE ticket_id = {id}";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                MySqlDataReader reader = read.ExecuteReader();
                int t_id = reader.GetInt32("ticket_id");
                string name = reader.GetString("name");
                int price = reader.GetInt32("price");
                string description = reader.GetString("description");
                string image = reader.GetString("image");
                selectedTicket = new Ticket(t_id, name, price, description, image);
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return selectedTicket;
        }
    }
}
