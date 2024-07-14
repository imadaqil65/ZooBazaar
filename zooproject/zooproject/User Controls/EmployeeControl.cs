using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Logic.Services.User;

namespace zooproject.User_Controls
{
    public partial class EmployeeControl : UserControl
    {
        Employee employee;
        Employees employeesPage;
        AddFeedingTask feedingTask;
        EmployeeManager employeeManager;
        public ModifyEmployee? modifyEmployee;

        public EmployeeControl(Employee employee ,Employees employees)
        {
            InitializeComponent();
            this.employee = employee;
            employeesPage = employees;
            employeeManager = new EmployeeManager(new DBEmployees());

            lblEmpName.Text = $"{employee.FirstName} {employee.LastName}";
            lblDeparment.Text = $"Dep: {employee.Job}";
            DateTime birthdate = employee.BirthDate;
            lblDateOfBirth.Text = $"DoB: {birthdate.ToShortDateString()}";
        }

        public EmployeeControl(Employee employee, AddFeedingTask feedingTask)
        {
            InitializeComponent();
            this.employee = employee;
            this.feedingTask = feedingTask;

            lblEmpName.Text = $"{employee.FirstName} {employee.LastName}";
            lblDeparment.Text = $"Dep: {employee.Job}";
            DateTime birthdate = employee.BirthDate;
            lblDateOfBirth.Text = $"DoB: {birthdate.ToShortDateString()}";
        }
        private void EmpDetailsBtn_Click(object sender, EventArgs e)
        {
            if (Counter.GetMoveModifyAnimalFormCounter() == 0)
            {
                Counter.UpdateMoveModifyAnimalFormCounter();
                this.BackColor = Color.LimeGreen;
                if (modifyEmployee == null)
                {
                    modifyEmployee = new ModifyEmployee(employeesPage, employee, this);
                    modifyEmployee.StartPosition = FormStartPosition.Manual;
                    modifyEmployee.Location = new Point(employeesPage.Location.X + 889, employeesPage.Location.Y);
                    modifyEmployee.Show();
                }
            }
        }
    }
}
