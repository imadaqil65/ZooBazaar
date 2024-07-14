using Domain.Domain.Exceptions;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.Exceptions;
using zooproject.Domain.Domain.User;
using zooproject.Infrastructure.Databases.Employees;

namespace zooproject.Logic.Services.User
{
    public class EmployeeManager
    {
        IDBEmployees datasource;
        public EmployeeManager(IDBEmployees source)
        {
            datasource = source;
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> Employees = new List<Employee>();
            foreach (Employee employee in datasource.ReadAllEmployees())
            {
                Employees.Add(employee);
            }
            return Employees;
        }
        public bool CheckAccount(string username, string password)
        {
            if (string.IsNullOrEmpty(username)) { throw new DomainException("Username cannot be empty!"); }
            if (string.IsNullOrEmpty(password)) { throw new DomainException("Password cannot be empty!"); }

            foreach (Employee emp in GetEmployees())
            {
                if (emp.Username == username && emp.Password == password && emp.Job == JobType.Admin)
                {
                    return true;
                }
                if (emp.Username == username && emp.Password == password)
                {
                    if (emp.Job != JobType.Admin) { throw new LoginException("User is not an Admin"); }
                }
                if (emp.Username == username && emp.Password != password)
                {
                    throw new LoginException("Username and Password don't match!");
                }
            }
            return false;
        }

        public Employee? CheckEmployee(string empSearch)
        {
            foreach (Employee emp in GetEmployees())
            {
                if (empSearch == emp.FirstName || empSearch == emp.LastName)
                {
                    return emp;
                }
            }
            return null;
        }

        public void CreateEmployee(JobType job, Rank rank, DateTime startDate, string firstname, string lastname, Gender usergender, string email, string username, string password, DateTime birthdate, int phoneNumber, int bSN, string specialication)
        {
            Employee newEmployee = new Employee(job, rank, startDate, firstname, lastname, phoneNumber, usergender, bSN, email, username, password, birthdate, specialication);
            datasource.AddEmployee(newEmployee);
        }

        public void UpdateEmployeeData(Employee employee)
        {
            datasource.UpdateEmployee(employee);
        }
        public void RemoveEmployee(Employee employee)
        {
            datasource.DeleteEmployee(employee);
        }
        public Employee GetLastAddedEmployee()
        {
            return datasource.GetLastAddedEmployee();
        }
        public bool CheckUsername(string userName)
        {
            List<Employee> employees = datasource.ReadAllEmployees();
            foreach (Employee employee in employees)
            {
                if (userName == employee.Username)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckPassword(string password)
        {
            List<Employee> employees = datasource.ReadAllEmployees();
            foreach (Employee employee in employees)
            {
                if (password == employee.Password)
                {
                    return true;
                }
            }
            return false;
        }
        public string GetHashByUserName(string userName)
        {
            return datasource.GetHashByUserName(userName);
        }
        public int GetID(string userName)
        {
            List<Employee> employees = datasource.ReadAllEmployees();
            foreach (Employee employee in employees)
            {
                if (userName == employee.Username)
                {
                    return employee.Id;
                }
            }
            throw new UserNonExistantException("No User Was Found");
        }
    }
}