using Domain.Domain.Enums;
using Domain.Domain.Feeding;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Animals;

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
            string command = "INSERT INTO `zb_feeding`(`ExhibitID`, `FeedingDate`, `FeedingTimeSlot`, `EmployeeLimit`, `AnimalID`) VALUES (@exhibitID,@FeedingDate,@feedingTimeslot,@employeeLimit, @animalID)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@exhibitID", feedingTask.ExhibitID);
                add.Parameters.AddWithValue("@FeedingDate", feedingTask.FeedingDate);
                add.Parameters.AddWithValue("@feedingTimeslot", Convert.ToInt32(feedingTask.FeedingTimeSlot));
                add.Parameters.AddWithValue("@employeeLimit", feedingTask.EmployeeLimit);
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
        public void AssignEmployee(FeedingTask feedingTask, Employee employee)
        {
            string command = "INSERT INTO `zb_feedingconnection`(`FeedingID`, `EmployeeID`) VALUES (@feedingID,@employeeID)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@feedingID", feedingTask.ID);
                add.Parameters.AddWithValue("@employeeID", employee.Id);
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

        public List<FeedingTask> GetAllFeedingTasks(DateTime first, DateTime last)
        {
            List<FeedingTask> results = new List<FeedingTask>();



            string command = "SELECT zb_feeding.*\r\n  FROM (\r\n    SELECT *\r\n    FROM zb_feeding\r\n    GROUP BY FeedingTimeSlot\r\n  ) filtered_feedingtasks\r\n  JOIN zb_feeding\r\n  WHERE zb_feeding.FeedingDate BETWEEN @first AND @last\r\nORDER BY FeedingDate\r\n";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("@first", first);
                read.Parameters.AddWithValue("@last", last);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    int exhibitID = reader.GetInt32("ExhibitID");
                    DateTime feedingDateTime = reader.GetDateTime("FeedingDate");
                    FeedingTimeSlot feedingTimeSlot = (FeedingTimeSlot)reader.GetInt32("FeedingTimeSlot");
                    int employeeLimit = reader.GetInt32("EmployeeLimit");
                    int animalID = reader.GetInt32("AnimalID");

                    results.Add(new FeedingTask(id,exhibitID,feedingDateTime,feedingTimeSlot, employeeLimit, GetEmployeeIDS(id), animalID));
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
        private List<int> GetEmployeeIDS(int id)
        {
            List<int> results = new List<int>();



            string command = "SELECT * FROM `zb_feedingconnection` WHERE FeedingID = @feedingID";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("@feedingID", id);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int idresult = reader.GetInt32("EmployeeID");
                    


                    results.Add(idresult);
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
                    DateTime feedingDateTime = reader.GetDateTime("FeedingDate");
                    FeedingTimeSlot feedingTimeSlot = (FeedingTimeSlot)reader.GetInt32("FeedingTimeSlot");
                    int employeeLimit = reader.GetInt32("AnimalID");
                    int animalID = reader.GetInt32("AnimalID");

                    results.Add(new FeedingTask(idResult, exhibitID, feedingDateTime,feedingTimeSlot, employeeLimit,GetEmployeeIDS(id), animalID));
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
            string command = "UPDATE `zb_feeding` SET `ExhibitID`=@exhibitID,`FeedingDate`=@feedingDate,`FeedingTimeSlot`=@feedingTimeSlot,`EmployeeLimit`=@employeeLimit WHERE id = @id";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@exhibitID", feedingTask.ExhibitID);
                add.Parameters.AddWithValue("@feedingDate", feedingTask.FeedingDate);
                add.Parameters.AddWithValue("@feedingtimeslot", Convert.ToInt32(feedingTask.FeedingTimeSlot));
                add.Parameters.AddWithValue("@employeeLimit", feedingTask.EmployeeLimit);
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

        public List<Employee> GetTaskEmployees(int id)
        {
            List<Employee> results = new List<Employee>();



            string command = "SELECT * FROM `zb_feedingconnection` INNER JOIN zb_employees ON zb_feedingconnection.EmployeeID = zb_employees.id WHERE zb_feedingconnection.FeedingID = @id";
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
                    string firstName = reader.GetString("FirstName");
                    string lastName = reader.GetString("LastName");
                    Gender gender = (Gender)reader.GetInt32("Gender");
                    string email = reader.GetString("Email");
                    int bsn = reader.GetInt32("BSN");
                    int phoneNumber = reader.GetInt32("PhoneNumber");
                    string specialization = reader.GetString("Specialication");
                    string username = reader.GetString("UserName");
                    string password = reader.GetString("Password");
                    DateTime birthDate = reader.GetDateTime("BirthDate");
                    JobType jobType = (JobType)reader.GetInt32("Job");
                    Rank rank = (Rank)reader.GetInt32("Rank");
                    DateTime startDate = reader.GetDateTime("StartDate");
                    DateTime? endDate; if (!reader.IsDBNull(reader.GetOrdinal("EndDate")))
                    { endDate = reader.GetDateTime("EndDate"); }
                    else { endDate = null; }
                    int contracthours = reader.GetInt32("ContractHours");
                    WorkContract workContract = (WorkContract)reader.GetInt32("ContractType");

                    results.Add(new Employee(jobType,rank,startDate,endDate,id, firstName, lastName,phoneNumber,gender,bsn,email,username,password,birthDate,specialization, contracthours, workContract));
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

        public bool GetTaskByDateBool(DateTime feedingDate, int id)
        {
            List<FeedingTask> results = new List<FeedingTask>();



            string command = "SELECT `id`, `ExhibitID`, `FeedingDate`, `FeedingTimeSlot`, `EmployeeLimit`, `AnimalID` FROM `zb_feeding` WHERE FeedingDate = @feedingDate AND ExhibitID = @id;";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("@feedingDate", feedingDate.Date);
                read.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int idResult = reader.GetInt32("id");
                    int exhibitID = reader.GetInt32("ExhibitID");
                    DateTime feedingDateTime = reader.GetDateTime("FeedingDate");
                    FeedingTimeSlot feedingTimeSlot = (FeedingTimeSlot)reader.GetInt32("FeedingTimeSlot");
                    int employeeLimit = reader.GetInt32("EmployeeLimit");
                    int animalID = reader.GetInt32("AnimalID");

                    results.Add(new FeedingTask(idResult, exhibitID, feedingDateTime, feedingTimeSlot, employeeLimit, GetEmployeeIDS(id), animalID));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
                
            }
            if (results.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<FeedingTask> GetTaskByDateAndAnimal(DateTime start, DateTime end, int animalID)
        {
            List<FeedingTask> results = new List<FeedingTask>();



            string command = "SELECT * FROM `zb_feeding` WHERE `AnimalID` = @animalID AND `FeedingDate` BETWEEN @start AND @end;";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("@animalID", animalID);
                read.Parameters.AddWithValue("@start", start);
                read.Parameters.AddWithValue("@end", end);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int idResult = reader.GetInt32("id");
                    int exhibitID = reader.GetInt32("ExhibitID");
                    DateTime feedingDateTime = reader.GetDateTime("FeedingDate");
                    FeedingTimeSlot feedingTimeSlot = (FeedingTimeSlot)reader.GetInt32("FeedingTimeSlot");
                    int employeeLimit = reader.GetInt32("EmployeeLimit");
                    int animalIDResult = reader.GetInt32("AnimalID");

                    results.Add(new FeedingTask(idResult, exhibitID, feedingDateTime, feedingTimeSlot, employeeLimit, animalIDResult));
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

        public List<FeedingTask> GetFeedingTaskByDatesAndAnimalSpecies(DateTime start, DateTime end, AnimalSpecies animalSpecies)
        {
            List<FeedingTask> results = new List<FeedingTask>();



            string command = "SELECT zb_feeding.*, zb_animals.Species\r\nFROM (\r\n    SELECT *   FROM zb_feeding\r\n    GROUP BY FeedingTimeSlot  ) \r\n    filtered_feedingtasks\r\n    JOIN zb_feeding\r\n    JOIN zb_animals ON zb_feeding.AnimalID = zb_animals.idAuto\r\n    WHERE zb_feeding.FeedingDate BETWEEN  @first AND @last AND zb_animals.Species = @species ORDER BY FeedingDate";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("@first", start);
                read.Parameters.AddWithValue("@last", end);
                read.Parameters.AddWithValue("@species", animalSpecies);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    int exhibitID = reader.GetInt32("ExhibitID");
                    DateTime feedingDateTime = reader.GetDateTime("FeedingDate");
                    FeedingTimeSlot feedingTimeSlot = (FeedingTimeSlot)reader.GetInt32("FeedingTimeSlot");
                    int employeeLimit = reader.GetInt32("EmployeeLimit");
                    int animalID = reader.GetInt32("AnimalID");

                    results.Add(new FeedingTask(id, exhibitID, feedingDateTime, feedingTimeSlot, employeeLimit, GetEmployeeIDS(id), animalID));
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
    }
}
