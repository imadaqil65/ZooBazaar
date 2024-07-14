using Domain.Domain.Country;
using MySql.Data.MySqlClient;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.User;

namespace zooproject.Infrastructure.Databases.Visitors
{
    public class DBVisitor : IDBVisitor
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
            return conn;

        }
        public void AddVisitor(Visitor v)
        {
            string command = "INSERT INTO `zb_visitors`(`id`, `FirstName`, `LastName`, `Email`, `UserName`, `Password`,`Adress`,`Country`) VALUES (NULL,@firstName,@lastName,@email,@userName,@password,@adress,@country)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@firstName", v.FirstName);
                add.Parameters.AddWithValue("@lastName", v.LastName);
/*                add.Parameters.AddWithValue("@gender", v.UserGender);*/
                add.Parameters.AddWithValue("@email", v.Email);
                add.Parameters.AddWithValue("@userName", v.Username);
                add.Parameters.AddWithValue("@password", v.Password);
				add.Parameters.AddWithValue("@adress", v.Adress);
				add.Parameters.AddWithValue("@country", v.Country);
				/*                add.Parameters.AddWithValue("@birthDate", v.BirthDate);
								add.Parameters.AddWithValue("@rank", Rank.Visitor.ToString());*/

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

        public void DeleteVisitor(Visitor v)
        {
            string command = "DELETE FROM `zb_visitors` WHERE id = @ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@ID", v.Id);
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

        public List<Visitor> ReadAllVisitors()
        {
            List<Visitor> visitors = new List<Visitor>();


            string command = "SELECT * FROM `zb_visitors`";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();

                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string firstName = reader.GetString("FirstName");
                    string lastName = reader.GetString("LastName");
                    string email = reader.GetString("Email");
                    string username = reader.GetString("UserName");
                    string password = reader.GetString("Password");
                    string adress = reader.GetString("Adress");
                    Country country = (Country)reader.GetInt32("Country");

                    Visitor visitor = new Visitor(id,firstName, lastName, email, username, password, adress, country);
                    visitors.Add(visitor);
                    //TODO:fix consructor
                    /*                    visitors.Add(new Visitor(id,firstName,lastName,employeeGender,email,username,password,birthDate));
                    */
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }

            return visitors;
        }

        public void UpdateVisitor(Visitor v)
        {
            string command = "UPDATE `zb_visitors` SET `FirstName`=@firstName,`LastName`=@lastName,`Email`=@email,`UserName`=@userName,`Password`=@password, `Adress`=@adress, `Country`=@country WHERE id =@ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@firstName", v.FirstName);
                add.Parameters.AddWithValue("@lastName", v.LastName);
/*                add.Parameters.AddWithValue("@gender", v.UserGender);*/
                add.Parameters.AddWithValue("@email", v.Email);
                add.Parameters.AddWithValue("@userName", v.Username);
                add.Parameters.AddWithValue("@password", v.Password);
				add.Parameters.AddWithValue("@adress", v.Adress);
				add.Parameters.AddWithValue("@country", v.Country);
				/*                add.Parameters.AddWithValue("@birthDate", v.BirthDate);
								add.Parameters.AddWithValue("@rank", Rank.Visitor.ToString());*/
				add.Parameters.AddWithValue("@ID", v.Id);

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

		public Visitor SearchVisitorById(int id)
		{
			string command = $"SELECT * FROM zb_visitors WHERE id ='{id}'";
            Visitor searchedVisitor = null;
			MySqlConnection conn = GetConnection();
			MySqlCommand search = new MySqlCommand(command, conn);
			try
			{
				conn.Open();

				MySqlDataReader reader = search.ExecuteReader();
				while (reader.Read())
				{
					int Id = reader.GetInt32("id");
					string firstName = reader.GetString("FirstName");
					string lastName = reader.GetString("LastName");
					string email = reader.GetString("Email");
					string username = reader.GetString("UserName");
					string password = reader.GetString("Password");
                    string adress = reader.GetString("Adress");
                    Country country = (Country)reader.GetInt32("Country");

					Visitor visitor = new Visitor(id, firstName, lastName, email, username, password, adress, country);
                    searchedVisitor = visitor;
					//TODO:fix consructor
					/*                    visitors.Add(new Visitor(id,firstName,lastName,employeeGender,email,username,password,birthDate));
                    */
				}

			}
			//TODO: work on proper exhceptions
			catch { }
			finally
			{
				conn.Close();
			}

			return searchedVisitor;
		}

		public bool CheckEmail(string email)
		{
			bool check = false;
			string command = "SELECT * FROM zb_visitors WHERE email = @email";
			MySqlConnection conn = GetConnection();
			MySqlCommand search = new MySqlCommand(command, conn);
			search.Parameters.AddWithValue("@email", email);

			try
			{
				conn.Open();
				using (MySqlDataReader reader = search.ExecuteReader())
				{
					check = reader.HasRows;
				}
			}
			catch (Exception ex)
			{
				// TODO: Properly handle the exception (e.g., log, throw, or handle the error)
				throw ex;
			}
			finally
			{
				conn.Close();
			}

			return check;
		}

	}
}