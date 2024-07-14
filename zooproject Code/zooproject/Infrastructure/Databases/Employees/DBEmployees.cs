using MySql.Data.MySqlClient;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.User;

namespace zooproject.Infrastructure.Databases.Employees
{
    public class DBEmployees : IDBEmployees
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
            return conn;

        }
        public void AddEmployee(Employee e)
        {
            string command = "INSERT INTO `zb_employees`(`id`, `FirstName`, `LastName`, `Gender`, `Email`, `BSN`, `PhoneNumber`, `Specialication`, `UserName`, `Password`, `BirthDate`, `Job`, `Rank`, `StartDate`) VALUES (NULL,@firstName,@lastName,@gender,@email,@bsn,@phoneNumber,@specialication,@userName,@password,@birthDate,@job,@rank,@startDate)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@firstName", e.FirstName);
                add.Parameters.AddWithValue("@lastName", e.LastName);
                add.Parameters.AddWithValue("@gender", e.UserGender);
                add.Parameters.AddWithValue("@email", e.Email);
                add.Parameters.AddWithValue("@bsn", e.BSN);
                add.Parameters.AddWithValue("@phoneNumber", e.PhoneNumber);
                add.Parameters.AddWithValue("@userName", e.Username);
                add.Parameters.AddWithValue("@password", e.Password);
                add.Parameters.AddWithValue("@birthDate", e.BirthDate);
                add.Parameters.AddWithValue("@job", e.Job);
                add.Parameters.AddWithValue("@rank", e.UserRank);
                add.Parameters.AddWithValue("@startDate", e.StartDate);
                add.Parameters.AddWithValue("@specialication", e.Specialication);

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

        public void DeleteEmployee(Employee e)
        {
            string command = "DELETE FROM `zb_employees` WHERE id = @ID";
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

        public List<Employee> ReadAllEmployees()
        {
            List<Employee> employees = new List<Employee>();


            string command = "SELECT * FROM `zb_employees`";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();

                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    JobType jobType = (JobType)reader.GetInt32("Job");
                    Rank rank = (Rank)reader.GetInt32("Rank");
                    DateTime startDate = reader.GetDateTime("StartDate");
                    int id = reader.GetInt32("id");
                    string firstName = reader.GetString("FirstName");
                    string lastName = reader.GetString("LastName");
                    Gender employeeGender = (Gender)reader.GetInt32("Gender");
                    string email = reader.GetString("Email");
                    string username = reader.GetString("UserName");
                    string password = reader.GetString("Password");
                    DateTime birthDate = reader.GetDateTime("BirthDate");
                    string specialication = reader.GetString("Specialication");
                    int phoneNumber = reader.GetInt32("PhoneNumber");
                    int bSN = reader.GetInt32("BSN");
                    employees.Add(new Employee(jobType, rank, startDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication));
                }


            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }

            return employees;
        }

        public void UpdateEmployee(Employee e)
        {
            string command = "UPDATE `zb_employees` SET `id`=@ID,`FirstName`=@firstName,`LastName`=@lastName,`Gender`=@gender,`Email`=@email,`BSN`=@bsn,`PhoneNumber`=@phoneNumber,`Specialication`=@Specialication,`UserName`=@userName,`Password`=@password,`BirthDate`=@birthDate,`Job`=@job,`Rank`=@rank,`StartDate`=@startDate WHERE id =@ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@firstName", e.FirstName);
                add.Parameters.AddWithValue("@lastName", e.LastName);
                add.Parameters.AddWithValue("@gender", e.UserGender);
                add.Parameters.AddWithValue("@email", e.Email);
                add.Parameters.AddWithValue("@bsn", e.BSN);
                add.Parameters.AddWithValue("@phoneNumber", e.PhoneNumber);
                add.Parameters.AddWithValue("@Specialication", e.Specialication);
                add.Parameters.AddWithValue("@userName", e.Username);
                add.Parameters.AddWithValue("@password", e.Password);
                add.Parameters.AddWithValue("@birthDate", e.BirthDate);
                add.Parameters.AddWithValue("@job", e.Job);
                add.Parameters.AddWithValue("@rank", e.UserRank);
                add.Parameters.AddWithValue("@startDate", e.StartDate);
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
        public Employee GetLastAddedEmployee()
        {
            string command = "SELECT * FROM `zb_employees` ORDER BY id DESC LIMIT 1";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    JobType jobType = (JobType)reader.GetInt32("Job");
                    Rank rank = (Rank)reader.GetInt32("Rank");
                    DateTime startDate = reader.GetDateTime("StartDate");
                    int id = reader.GetInt32("id");
                    string firstName = reader.GetString("FirstName");
                    string lastName = reader.GetString("LastName");
                    Gender employeeGender = (Gender)reader.GetInt32("Gender");
                    string email = reader.GetString("Email");
                    string username = reader.GetString("UserName");
                    string password = reader.GetString("Password");
                    DateTime birthDate = reader.GetDateTime("BirthDate");
                    string specialication = reader.GetString("Specialication");
                    int phoneNumber = reader.GetInt32("PhoneNumber");
                    int bSN = reader.GetInt32("BSN");
                    Employee emp = new Employee(jobType, rank, startDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication);
                    return emp;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            Employee emptyEmp = null;
            return emptyEmp;
        }
        public Employee GetEmployeeById(int ID)
        {
            string command = "SELECT * FROM `zb_employees` WHERE id=" + ID;
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    JobType jobType = (JobType)reader.GetInt32("Job");
                    Rank rank = (Rank)reader.GetInt32("Rank");
                    DateTime startDate = reader.GetDateTime("StartDate");
                    int id = reader.GetInt32("id");
                    string firstName = reader.GetString("FirstName");
                    string lastName = reader.GetString("LastName");
                    Gender employeeGender = (Gender)reader.GetInt32("Gender");
                    string email = reader.GetString("Email");
                    string username = reader.GetString("UserName");
                    string password = reader.GetString("Password");
                    DateTime birthDate = reader.GetDateTime("BirthDate");
                    string specialication = reader.GetString("Specialication");
                    int phoneNumber = reader.GetInt32("PhoneNumber");
                    int bSN = reader.GetInt32("BSN");
                    Employee emp = new Employee(jobType, rank, startDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication);
                    return emp;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            Employee emptyEmp = null;
            return emptyEmp;
        }
        public string GetHashByUserName(string userName)
        {
            string hash = "";
            string command = "SELECT * FROM `zb_employees` WHERE UserName = @username";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                read.Parameters.AddWithValue("@username", userName);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    hash = reader.GetString("Password");
                }
            }
            catch
            {
                //TODO: work on proper exhceptions
            }
            finally
            {
                conn.Close();
            }
            return hash;
        }
    }
}