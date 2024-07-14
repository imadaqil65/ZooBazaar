using zooproject.Domain.Domain.User;

namespace zooproject.Infrastructure.Databases.Employees
{
    public interface IDBEmployees
    {
        public void AddEmployee(Employee e);
        public void DeleteEmployee(Employee e);
        public void UpdateEmployee(Employee e);
        public List<Employee> ReadAllEmployees();
        public Employee GetLastAddedEmployee();
        public Employee GetEmployeeById(int ID);
        public string GetHashByUserName(string userName);

    }
}