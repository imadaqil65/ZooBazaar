using MySql.Data.MySqlClient;
using zooproject.Domain.Domain.User;

namespace zooproject.Infrastructure.Databases.WorkAssignments
{
    public class DBWorkAssignment
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
            return conn;

        }
        public void AddWorkAssignment(WorkAssignment work)
        {
            string command = "INSERT INTO `zb_workassignment`(`Name`, `AssignmentDate`, `RequiredRank`, `ExhibitId`) VALUES (@name, @assignmentdate, @requiredrank, @exhibitid)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@name", work.Name);
                add.Parameters.AddWithValue("@assignmentdate", work.AssignmentDate);
                add.Parameters.AddWithValue("@requiredrank", work.RequiredRank);
                add.Parameters.AddWithValue("@exhibitid", work.AssignedExhibitId);

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

        public void DeleteWorkAssignment(WorkAssignment work)
        {
            string command = "DELETE FROM `zb_workassignment` WHERE id = @ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@ID", work.Id);
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

        public List<WorkAssignment> ReadAllWorkAssignments()
        {
            List<WorkAssignment> works = new List<WorkAssignment>();


            string command = "SELECT * FROM `zb_workassignment`";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();

                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("Id");
                    string name = reader.GetString("Name");
                    DateTime assignmentdate = reader.GetDateTime("AssignmentDate");
                    Rank requiredrank = (Rank)reader.GetInt32("RequiredRank");
                    int exhibitid = reader.GetInt32("ExhibitId");
                    int employeeid = reader.GetInt32("EmployeeId");
                    works.Add(new WorkAssignment(id, name, assignmentdate, requiredrank, exhibitid, employeeid));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }

            return works;
        }

        public void UpdateWorkAssignment(WorkAssignment work)
        {
            string command = "UPDATE `zb_workassignment` SET `Id`=@ID,`Name`=@Name, `AssignmentDate`=@AssignmentDate, `RequiredRank`=@RequiredRank, `ExhibitId`=@ExhibitId, `EmployeeId`@EmployeeId WHERE id =@ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@ID", work.Id);
                add.Parameters.AddWithValue("@Name", work.Name);
                add.Parameters.AddWithValue("@AssignmentDate", work.AssignmentDate);
                add.Parameters.AddWithValue("@RequiredRank", work.RequiredRank);
                add.Parameters.AddWithValue("@ExhibitId", work.AssignedExhibitId);
                add.Parameters.AddWithValue("@EmployeeId", work.AssignedEmployeeId);


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