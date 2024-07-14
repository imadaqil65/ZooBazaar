using MySql.Data.MySqlClient;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Infrastructure.Databases.Zones
{
    public class ZoneDB : IZoneDB
    {

        public MySqlConnection GetConnection()
        {
            MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
            return conn;

        }
        public void AddZone(Zone z)
        {
            string command = "INSERT INTO `zb_zone`(`Name`) VALUES (@name)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@name", z.Name);

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

        public void DeleteZone(Zone z)
        {
            string command = "DELETE FROM `zb_zone` WHERE id = @ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@ID", z.ZoneId);
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

        public List<Zone> ReadAllZones()
        {
            List<Zone> zones = new List<Zone>();


            string command = "SELECT * FROM `zb_zone`";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();

                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("Name");
                    zones.Add(new Zone(name, id));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }

            return zones;
        }

        public void UpdateZone(Zone z)
        {
            string command = "UPDATE `zb_zone` SET `Name`=@name WHERE id = @ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@name", z.Name);
                add.Parameters.AddWithValue("@ID", z.ZoneId);
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
        public Zone GetZoneWithID(int id)
        {
			string command = "SELECT * FROM `zb_zone` WHERE id = @ID";
			MySqlConnection conn = GetConnection();
			MySqlCommand add = new MySqlCommand(command, conn);
            Zone zone = new Zone();
            try
			{
				conn.Open();
				add.Parameters.AddWithValue("@ID", id);
                MySqlDataReader reader = add.ExecuteReader();
                while(reader.Read()) 
                {
					int ID = reader.GetInt32("id");
					string name = reader.GetString("name");
					zone = new Zone(name, ID);
				}
			}
			//TODO: work on proper exhceptions
			catch (Exception ex)
			{
            
            }
			finally
            {
				conn.Close();
			}
			return zone;
		}
	}
}