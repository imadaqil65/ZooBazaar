using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Connections;

namespace zooproject.Infrastructure.Databases.Employees
{
    public class RemoveEmployeeDB : IDBEmployees
    {
        Connection connection = new Connection();
        public void AddEmployee(Employee e)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = "INSERT INTO `zb_removedemployees`(`employee_id`, `FirstName`, `LastName`, `Gender`, `email`, `bsn`, `phone`, `Specialization`, `Username`, `Password`, `Birthdate`, `job`, `rank`, `Leave_Date`, `Fired`, `Leave_reason`) VALUES (@Id,@firstName,@lastName,@gender,@email,@bsn,@phoneNumber,@specialication,@userName,@password,@birthDate,@job,@rank,@endDate,@Fired,@Leavereason)";
                MySqlCommand add = new MySqlCommand(command, conn);
                try
                {
                    add.Parameters.AddWithValue("@Id", e.Id);
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
                    add.Parameters.AddWithValue("@specialication", e.Specialication);
                    add.Parameters.AddWithValue("@endDate", e.EndDate);
                    add.Parameters.AddWithValue("@Leavereason", e.LeavingReason);
                    add.Parameters.AddWithValue("@Fired", e.Fired);

                    MySqlDataReader reader = add.ExecuteReader();
                }
                //TODO: work on proper exhceptions
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        public void DeleteEmployee(Employee e)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = "DELETE FROM `zb_removedemployees` WHERE employee_id = @ID";
                MySqlCommand add = new MySqlCommand(command, conn);
                try
                {
                    add.Parameters.AddWithValue("@ID", e.Id);
                    MySqlDataReader reader = add.ExecuteReader();
                }
                //TODO: work on proper exhceptions
                catch (Exception ex)
                {
                    return;
                }
            }
        }
        public List<Employee> ReadAllEmployees()
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                List<Employee> employees = new List<Employee>();
                string command = "SELECT * FROM `zb_removedemployees`";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
                    MySqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("employee_id");
                        string firstName = reader.GetString("Firstname");
                        string lastName = reader.GetString("Lastname");
                        Gender employeeGender = (Gender)reader.GetInt32("Gender");
                        string email = reader.GetString("email");
                        int bSN = reader.GetInt32("bsn");
                        int phoneNumber = reader.GetInt32("phone");
                        string specialication = reader.GetString("Specialization");
                        string username = reader.GetString("Username");
                        string password = reader.GetString("Password");
                        DateTime birthDate = reader.GetDateTime("Birthdate");
                        JobType jobType = (JobType)reader.GetInt32("job");
                        Rank rank = (Rank)reader.GetInt32("rank");
                        DateTime endDate = reader.GetDateTime("Leave_date");
                        bool Fired = reader.GetBoolean("Fired");
                        string Leavereason = reader.GetString("Leave_reason");
                        employees.Add(new Employee(jobType, rank, endDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication, Fired, Leavereason));
                    }
                }
                //TODO: work on proper exhceptions
                catch
                {

                }
                return employees;
            }
        }

        public List<Employee> GetActiveEmployee(DateTime activedate)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee e)
        {
            throw new NotImplementedException();
        }
        public Employee GetLastAddedEmployee()
        {
            throw new NotImplementedException();
        }
        public Employee GetEmployeeById(int ID)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = $"SELECT * FROM `zb_removedemployees` WHERE employee_id=@ID";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
                    read.Parameters.AddWithValue("@ID", ID);
                    MySqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        JobType jobType = (JobType)reader.GetInt32("Job");
                        Rank rank = (Rank)reader.GetInt32("Rank");
                        DateTime endDate = reader.GetDateTime("Leave_Date");
                        int id = reader.GetInt32("id");
                        string firstName = reader.GetString("Firstname");
                        string lastName = reader.GetString("Lastname");
                        Gender employeeGender = (Gender)reader.GetInt32("Gender");
                        string email = reader.GetString("email");
                        string username = reader.GetString("Username");
                        string password = reader.GetString("Password");
                        DateTime birthDate = reader.GetDateTime("Birthdate");
                        string specialication = reader.GetString("Specialization");
                        int phoneNumber = reader.GetInt32("phone");
                        int bSN = reader.GetInt32("bsn");
                        bool Fired = reader.GetBoolean("Fired");
                        string Leavereason = reader.GetString("Leave_reason");
                        Employee emp = new Employee(jobType, rank, endDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication, Fired, Leavereason);
                        return emp;
                    }
                }
                catch (Exception ex)
                {

                }
                Employee emptyEmp = null;
                return emptyEmp;
            }
        }
        public string GetHashByUserName(string userName)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string hash = "";
                string command = "SELECT `Password` FROM `zb_removedemployees` WHERE Username = @username";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
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
                return hash;
            }
        }

        public List<Employee> GetEmployeeBySpecialization(Animal animal)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                List<Employee> employees = new List<Employee>();
                string command = "SELECT * FROM `zb_rmeovedemployees` WHERE Specialization = @specialization";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
                    read.Parameters.AddWithValue("@specialization", animal.Species.ToString());
                    MySqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        JobType jobType = (JobType)reader.GetInt32("Job");
                        Rank rank = (Rank)reader.GetInt32("Rank");
                        DateTime endDate = reader.GetDateTime("Leave_Date");
                        int id = reader.GetInt32("id");
                        string firstName = reader.GetString("Firstname");
                        string lastName = reader.GetString("Lastname");
                        Gender employeeGender = (Gender)reader.GetInt32("Gender");
                        string email = reader.GetString("email");
                        string username = reader.GetString("Username");
                        string password = reader.GetString("Password");
                        DateTime birthDate = reader.GetDateTime("Birthdate");
                        string specialication = reader.GetString("Specialization");
                        int phoneNumber = reader.GetInt32("phone");
                        int bSN = reader.GetInt32("bsn");
                        bool Fired = reader.GetBoolean("Fired");
                        string Leavereason = reader.GetString("Leave_reason");
                        Employee emp = new Employee(jobType, rank, endDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication, Fired, Leavereason);
                    }
                }
                //TODO: work on proper exhceptions
                catch
                {

                }
                return employees;
            }
        }

        public List<Employee> GetEmployeeByTaskAndDates(int task, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
