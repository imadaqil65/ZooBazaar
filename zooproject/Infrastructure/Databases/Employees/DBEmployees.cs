using Domain.Domain.Enums;
using MySql.Data.MySqlClient;
using System.Diagnostics.Contracts;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Connections;

namespace zooproject.Infrastructure.Databases.Employees
{
    public class DBEmployees : IDBEmployees
    {
        Connection connection = new Connection();
        public void AddEmployee(Employee e)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = "INSERT INTO `zb_employees`(`id`, `FirstName`, `LastName`, `Gender`, `Email`, `BSN`, `PhoneNumber`, `Specialication`, `ContractHours`, `ContractType`, `UserName`, `Password`, `BirthDate`, `Job`, `Rank`, `StartDate`, `EndDate`) VALUES (NULL,@firstName,@lastName,@gender,@email,@bsn,@phoneNumber,@specialication,@contract,@type,@userName,@password,@birthDate,@job,@rank,@startDate,@endDate)";
                MySqlCommand add = new MySqlCommand(command, conn);
                try
                {
                    add.Parameters.AddWithValue("@firstName", e.FirstName);
                    add.Parameters.AddWithValue("@lastName", e.LastName);
                    add.Parameters.AddWithValue("@gender", e.UserGender);
                    add.Parameters.AddWithValue("@email", e.Email);
                    add.Parameters.AddWithValue("@bsn", e.BSN);
                    add.Parameters.AddWithValue("@phoneNumber", e.PhoneNumber);
                    add.Parameters.AddWithValue("@Specialication", e.Specialication);
                    add.Parameters.AddWithValue("@contract", e.ContractHours);
                    add.Parameters.AddWithValue("@type", e.Workcontract);
                    add.Parameters.AddWithValue("@userName", e.Username);
                    add.Parameters.AddWithValue("@password", e.Password);
                    add.Parameters.AddWithValue("@birthDate", e.BirthDate);
                    add.Parameters.AddWithValue("@job", e.Job);
                    add.Parameters.AddWithValue("@rank", e.UserRank);
                    add.Parameters.AddWithValue("@startDate", e.StartDate);
                    add.Parameters.AddWithValue("@endDate", e.EndDate);
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
        public void DeleteEmployee(Employee e)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = "DELETE FROM `zb_employees` WHERE id = @ID";
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
                string command = "SELECT * FROM `zb_employees`";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
                    MySqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        JobType jobType = (JobType)reader.GetInt32("Job");
                        Rank rank = (Rank)reader.GetInt32("Rank");
                        DateTime startDate = reader.GetDateTime("StartDate");
                        DateTime? endDate; if (!reader.IsDBNull(reader.GetOrdinal("EndDate")))
                        { endDate = reader.GetDateTime("EndDate"); } else { endDate = null; }
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
                        int contract = reader.GetInt32("ContractHours");
                        WorkContract workContract = (WorkContract)reader.GetInt32("ContractType");  
                        employees.Add(new Employee(jobType, rank, startDate, endDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication, contract, workContract));
                    }
                }
                //TODO: work on proper exhceptions
                catch
                {

                }
                return employees;
            }
        }
        public void UpdateEmployee(Employee e)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = "UPDATE `zb_employees` SET `id`=@ID,`FirstName`=@firstName,`LastName`=@lastName,`Gender`=@gender,`Email`=@email,`BSN`=@bsn,`PhoneNumber`=@phoneNumber,`Specialication`=@Specialication, `ContractHours`=@contract, `ContractType`=@type, `UserName`=@userName,`Password`=@password,`BirthDate`=@birthDate,`Job`=@job,`Rank`=@rank,`StartDate`=@startDate,`EndDate`=@endDate WHERE id =@ID";
                MySqlCommand add = new MySqlCommand(command, conn);
                try
                {
                    add.Parameters.AddWithValue("@firstName", e.FirstName);
                    add.Parameters.AddWithValue("@lastName", e.LastName);
                    add.Parameters.AddWithValue("@gender", e.UserGender);
                    add.Parameters.AddWithValue("@email", e.Email);
                    add.Parameters.AddWithValue("@bsn", e.BSN);
                    add.Parameters.AddWithValue("@phoneNumber", e.PhoneNumber);
                    add.Parameters.AddWithValue("@Specialication", e.Specialication);
                    add.Parameters.AddWithValue("@contract", e.ContractHours);
                    add.Parameters.AddWithValue("@type", e.Workcontract);
                    add.Parameters.AddWithValue("@userName", e.Username);
                    add.Parameters.AddWithValue("@password", e.Password);
                    add.Parameters.AddWithValue("@birthDate", e.BirthDate);
                    add.Parameters.AddWithValue("@job", e.Job);
                    add.Parameters.AddWithValue("@rank", e.UserRank);
                    add.Parameters.AddWithValue("@startDate", e.StartDate);
                    add.Parameters.AddWithValue("@endDate", e.EndDate);
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
        public Employee GetLastAddedEmployee()
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = "SELECT * FROM `zb_employees` ORDER BY id DESC LIMIT 1";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
                    MySqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        JobType jobType = (JobType)reader.GetInt32("Job");
                        Rank rank = (Rank)reader.GetInt32("Rank");
                        DateTime startDate = reader.GetDateTime("StartDate");
                        DateTime? endDate; if (!reader.IsDBNull(reader.GetOrdinal("EndDate")))
                        { endDate = reader.GetDateTime("EndDate"); } else { endDate = null; }
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
                        int contract = reader.GetInt32("ContractHours");
                        WorkContract workContract = (WorkContract)reader.GetInt32("ContractType");
                        Employee emp = new Employee(jobType, rank, startDate, endDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication, contract, workContract);
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
        public Employee GetEmployeeById(int ID)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string command = "SELECT * FROM `zb_employees` WHERE id=@ID";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
                    read.Parameters.AddWithValue("@ID", ID);
                    MySqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        JobType jobType = (JobType)reader.GetInt32("Job");
                        Rank rank = (Rank)reader.GetInt32("Rank");
                        DateTime startDate = reader.GetDateTime("StartDate");
                        DateTime? endDate; if (!reader.IsDBNull(reader.GetOrdinal("EndDate")))
                        { endDate = reader.GetDateTime("EndDate"); } else { endDate = null; }
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
                        int contract = reader.GetInt32("ContractHours");
                        int bSN = reader.GetInt32("BSN");
                        WorkContract workContract = (WorkContract)reader.GetInt32("ContractType");
                        Employee emp = new Employee(jobType, rank, startDate, endDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication, contract, workContract);
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

        public List<Employee> GetActiveEmployee(DateTime activedate)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                List<Employee> employees = new List<Employee>();
                string command = "SELECT * FROM `zb_employees` WHERE `StartDate` <= @activedate AND `EndDate` >= @activedate OR `StartDate` <= @activedate AND `EndDate` IS NULL";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
                    read.Parameters.AddWithValue("@activedate", activedate);
                    MySqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        JobType jobType = (JobType)reader.GetInt32("Job");
                        Rank rank = (Rank)reader.GetInt32("Rank");
                        DateTime startDate = reader.GetDateTime("StartDate");
                        DateTime? endDate; if (!reader.IsDBNull(reader.GetOrdinal("EndDate")))
                        { endDate = reader.GetDateTime("EndDate"); }
                        else { endDate = null; }
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
                        int contract = reader.GetInt32("ContractHours");
                        WorkContract workContract = (WorkContract)reader.GetInt32("ContractType");
                        employees.Add(new Employee(jobType, rank, startDate, endDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication, contract, workContract));
                    }
                }
                catch
                {

                }
                return employees;
            }
        }

        public string GetHashByUserName(string userName)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                string hash = string.Empty;
                string command = "SELECT `Password` FROM `zb_employees` WHERE UserName = @username";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
                    read.Parameters.AddWithValue("@username", userName);
                    MySqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        string temphash = reader.GetString("Password");
                        hash = temphash;
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
                string command = "SELECT * FROM `zb_employees` WHERE Specialication = @specialization";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
                    read.Parameters.AddWithValue("@specialization",animal.Species.ToString());
                    MySqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        JobType jobType = (JobType)reader.GetInt32("Job");
                        Rank rank = (Rank)reader.GetInt32("Rank");
                        DateTime startDate = reader.GetDateTime("StartDate");
                        DateTime? endDate; if (!reader.IsDBNull(reader.GetOrdinal("EndDate")))
                        { endDate = reader.GetDateTime("EndDate"); } else { endDate = null; }
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
                        int contract = reader.GetInt32("ContractHours");
                        WorkContract workContract = (WorkContract)reader.GetInt32("ContractType");
                        employees.Add(new Employee(jobType, rank, startDate, endDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication, contract, workContract));
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
            using (MySqlConnection conn = connection.GetConnection())
            {
                List<Employee> employees = new List<Employee>();
                string command = "SELECT zb_employees.* FROM `zb_employees` JOIN zb_feedingconnection ON zb_feedingconnection.EmployeeID = zb_employees.id JOIN zb_feeding ON zb_feeding.id = zb_feedingconnection.FeedingID WHERE zb_feeding.FeedingDate BETWEEN @startDate AND @endDate AND zb_feedingconnection.FeedingID = @taskID;";
                MySqlCommand read = new MySqlCommand(command, conn);
                try
                {
                    read.Parameters.AddWithValue("@startDate", start);
                    read.Parameters.AddWithValue("@endDate", end);
                    read.Parameters.AddWithValue("@taskID", task);
                    MySqlDataReader reader = read.ExecuteReader();
                    while (reader.Read())
                    {
                        JobType jobType = (JobType)reader.GetInt32("Job");
                        Rank rank = (Rank)reader.GetInt32("Rank");
                        DateTime startDate = reader.GetDateTime("StartDate");
                        DateTime? endDate; if (!reader.IsDBNull(reader.GetOrdinal("EndDate")))
                        { endDate = reader.GetDateTime("EndDate"); }
                        else { endDate = null; }
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
                        int contract = reader.GetInt32("ContractHours");
                        WorkContract workContract = (WorkContract)reader.GetInt32("ContractType");
                        employees.Add(new Employee(jobType, rank, startDate, endDate, id, firstName, lastName, phoneNumber, employeeGender, bSN, email, username, password, birthDate, specialication, contract, workContract));
                    }
                }
                catch
                {

                }
                return employees;
            }
        }
    }
}