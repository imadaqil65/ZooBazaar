using zooproject.Domain.Domain.User;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Logic.Services.User;

namespace zooproject.User_Controls
{
    public partial class RemovedEmployeeControl : UserControl
    {
        Employee employee;
        EmployeeManager employeeManager;
        EmployeeManager removalManager;
        RemovedEmployee employees;

        public RemovedEmployeeControl(Employee employee, RemovedEmployee employees)
        {
            InitializeComponent();

            employeeManager = new EmployeeManager(new DBEmployees());
            removalManager = new EmployeeManager(new RemoveEmployeeDB());
            this.employee = employee;
            this.employees = employees;

            label_name.Text = $"{employee.FirstName} {employee.LastName}";
            label_Department.Text = $"Dep: {employee.Job}";
            label_Specialization.Text = $"Spec: {employee.Specialication}";
        }

        private void button_Reinstate_Click(object sender, EventArgs e)
        {
            ReinstateEmployee reinstateemployee = new ReinstateEmployee(employees, employee);
            employees.Hide(); reinstateemployee.Show();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "This action is permanent \nAre you sure you want to delete?", "Deleting Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    removalManager.RemoveEmployee(employee); break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
