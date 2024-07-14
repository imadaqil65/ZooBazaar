using Domain.Domain.Feeding;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.Zoo;

namespace Infrastructure.Databases.Feeding
{
    public class FeedingDB : IDBFeeding
    {
        private MySqlConnection GetConnection()
        {
            MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
            return conn;

        }
        public void AddFeedingTask(FeedingTask feedingTask)
        {
            string command = "INSERT INTO `zb_feeding`(`ExhibitID`, `FeedingDateTime`, `AnimalID`) VALUES (@exhibitID,@feedingDateTime,@animalID)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@exhibitID", feedingTask.ExhibitID);
                add.Parameters.AddWithValue("@feedingDateTime", feedingTask.FeedingDateTime);
                add.Parameters.AddWithValue("@animalID", feedingTask.AnimalID);
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

        public void DeleteFeedingTask(FeedingTask feedingTask)
        {
            string command = "DELETE FROM `zb_feeding` WHERE id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@id", feedingTask.ID);
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

        public List<FeedingTask> GetAllFeedingTasks()
        {
            List<FeedingTask> results = new List<FeedingTask>();



            string command = "SELECT * FROM `zb_feeding`";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();

                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    int exhibitID = reader.GetInt32("ExhibitID");
                    DateTime feedingDateTime = reader.GetDateTime("FeedingDateTime");
                    int animalID = reader.GetInt32("AnimalID");


                    results.Add(new FeedingTask(id,exhibitID,feedingDateTime,animalID));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }
            return results;
        }

        public List<FeedingTask> GetFeedingTaskByID(int id)
        {
            List<FeedingTask> results = new List<FeedingTask>();



            string command = "SELECT * FROM `zb_feeding` WHERE id = @id";
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
                    int exhibitID = reader.GetInt32("ExhibitID");
                    DateTime feedingDateTime = reader.GetDateTime("FeedingDateTime");
                    int animalID = reader.GetInt32("AnimalID");


                    results.Add(new FeedingTask(idResult, exhibitID, feedingDateTime, animalID));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }
            return results;
        }

        public void UpdateFeedingTask(FeedingTask feedingTask)
        {
            string command = "UPDATE `zb_feeding` SET `ExhibitID`=@exhibitID,`FeedingDateTime`=@feedingDateTime,`AnimalID`=@animalID WHERE id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@exhibitID", feedingTask.ExhibitID);
                add.Parameters.AddWithValue("@feedingDateTime", feedingTask.FeedingDateTime);
                add.Parameters.AddWithValue("@animalID", feedingTask.AnimalID);
                add.Parameters.AddWithValue("@id", feedingTask.ID);
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
