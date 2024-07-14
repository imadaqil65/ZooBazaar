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

namespace zooproject.User_Controls
{
    public partial class EmployeeControl : UserControl
    {
        Employee employee;
        Employees employees;
        public EmployeeControl(Employee employee ,Employees employees)
        {
            InitializeComponent();
            this.employee = employee;
            this.employees = employees;

            lblEmpName.Text = employee.FirstName+ employee.LastName;
            lblDeparment.Text = employee.Job.ToString();
            DateTime birthdate = employee.BirthDate;
            lblDateOfBirth.Text = birthdate.ToShortDateString();
        }

        private void EmpDetailsBtn_Click(object sender, EventArgs e)
        {
            employees.FillEmployeeDetails(employee);
        }
    }
}
