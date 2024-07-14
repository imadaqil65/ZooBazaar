using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Infrastructure.Databases.Employees
{
    public interface IDBEmployees
    {
        public void AddEmployee(Employee e);
        public void DeleteEmployee(Employee e);
        public void UpdateEmployee(Employee e);
        public List<Employee> ReadAllEmployees();
        public Employee GetLastAddedEmployee();
        public List<Employee> GetActiveEmployee(DateTime activedate);
        public Employee GetEmployeeById(int ID);
        public string GetHashByUserName(string userName);
        public List<Employee> GetEmployeeBySpecialization(Animal animal);
        public List<Employee> GetEmployeeByTaskAndDates(int task, DateTime start, DateTime end);

    }
}