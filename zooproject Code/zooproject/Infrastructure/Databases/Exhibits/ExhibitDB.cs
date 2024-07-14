using MySql.Data.MySqlClient;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Infrastructure.Databases.Exhibits
{
    public class ExhibitDB : IExhibitDB
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
            return conn;

        }
        public void AddExhibit(Exhibit e)
        {
            string command = "INSERT INTO `zb_exhibit`(`id`, `Name`, `PredatorOrPrey`, `ExhibitType`, `ZoneId`) VALUES (NULL,@name,@predatorOrPrey,@exhibitType, @zoneID)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@name", e.Name);
                add.Parameters.AddWithValue("@predatorOrPrey", e.PredatorOrPrey);
                add.Parameters.AddWithValue("@exhibitType", e.ExhibitType);
                add.Parameters.AddWithValue("@zoneID", e.ZoneId);

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

        public void DeleteExhibit(Exhibit e)
        {
            string command = "DELETE FROM `zb_exhibit` WHERE id =@ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@ID", e.Id);
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

        public List<Exhibit> ReadAllExhibits()
        {
            List<Exhibit> exhibits = new List<Exhibit>();


            string command = "SELECT * FROM `zb_exhibit`";
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
                    bool predatorOrPrey = reader.GetBoolean("PredatorOrPrey");
                    EnviromentType exhibitType = (EnviromentType)reader.GetInt32("ExhibitType");
                    exhibits.Add(new Exhibit(id, name, predatorOrPrey, exhibitType));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }

            return exhibits;
        }

        public void UpdateExhibit(Exhibit e)
        {
            string command = "UPDATE `zb_exhibit` SET `Name`=@name,`PredatorOrPrey`=@predatorOrPrey,`ExhibitType`=@exhibitType, `ZoneId`=@zoneID WHERE id = @ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@name", e.Name);
                add.Parameters.AddWithValue("@predatorOrPrey", e.PredatorOrPrey);
                add.Parameters.AddWithValue("@exhibitType", e.ExhibitType);
                add.Parameters.AddWithValue("@zoneID", e.ZoneId);
                add.Parameters.AddWithValue("@ID", e.Id);
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


        public Exhibit ReadExhibitByID(int id)
        {
            Exhibit exhibit = null;
            string command = "SELECT * FROM `zb_exhibit` WHERE id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int idResult = reader.GetInt32("id");
                    string name = reader.GetString("Name");
                    bool predatorOrPrey = reader.GetBoolean("PredatorOrPrey");
                    EnviromentType exhibitType = (EnviromentType)reader.GetInt32("ExhibitType");
                    exhibit = new Exhibit(idResult, name, predatorOrPrey, exhibitType);
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }

            return exhibit;
        }
    }
}