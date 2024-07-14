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
            string command = "INSERT INTO `zb_visitors`(`id`, `FirstName`, `LastName`, `Gender`, `Email`, `UserName`, `Password`, `BirthDate`, `Rank`) VALUES (NULL,@firstName,@lastName,@gender,@email,@userName,@password,@birthDate,@rank)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@firstName", v.FirstName);
                add.Parameters.AddWithValue("@lastName", v.LastName);
                add.Parameters.AddWithValue("@gender", v.UserGender);
                add.Parameters.AddWithValue("@email", v.Email);
                add.Parameters.AddWithValue("@userName", v.Username);
                add.Parameters.AddWithValue("@password", v.Password);
                add.Parameters.AddWithValue("@birthDate", v.BirthDate);
                add.Parameters.AddWithValue("@rank", Rank.Visitor.ToString());

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
                    Gender employeeGender = (Gender)reader.GetInt32("Gender");
                    string email = reader.GetString("Email");
                    string username = reader.GetString("UserName");
                    string password = reader.GetString("Password");
                    DateTime birthDate = reader.GetDateTime("BirthDate");
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
            string command = "UPDATE `zb_employees` SET `id`=`FirstName`=@firstName,`LastName`=@lastName,`Gender`=@gender,`Email`=@email,`UserName`=@userName,`Password`=@password,`BirthDate`=@birthDate,`Rank`=@rank WHERE id =@ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@firstName", v.FirstName);
                add.Parameters.AddWithValue("@lastName", v.LastName);
                add.Parameters.AddWithValue("@gender", v.UserGender);
                add.Parameters.AddWithValue("@email", v.Email);
                add.Parameters.AddWithValue("@userName", v.Username);
                add.Parameters.AddWithValue("@password", v.Password);
                add.Parameters.AddWithValue("@birthDate", v.BirthDate);
                add.Parameters.AddWithValue("@rank", Rank.Visitor.ToString());
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
    }
}