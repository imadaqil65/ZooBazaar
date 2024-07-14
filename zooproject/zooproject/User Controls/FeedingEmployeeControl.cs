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
    public partial class FeedingEmployeeControl : UserControl
    {
        Employee employee;
        //Employees employees;
        AddFeedingTask feedingTask;
        //public EmployeeControl(Employee employee, Employees employees)
        //{
        //    InitializeComponent();
        //    this.employee = employee;
        //    this.employees = employees;

        //    lblEmpName.Text = employee.FirstName + " " + employee.LastName;
        //    lblDeparment.Text = employee.Job.ToString();
        //    DateTime birthdate = employee.BirthDate;
        //    lblDateOfBirth.Text = birthdate.ToShortDateString();
        //}

        public FeedingEmployeeControl(Employee employee, AddFeedingTask feedingTask)
        {
            InitializeComponent();
            this.employee = employee;
            this.feedingTask = feedingTask;

            lblEmpName.Text = employee.FirstName + " " + employee.LastName;
            lblDeparment.Text = employee.Job.ToString();
            DateTime birthdate = employee.BirthDate;
            lblDateOfBirth.Text = birthdate.ToShortDateString();
        }
     
        private void EmpSelectBtn_Click(object sender, EventArgs e)
        {
            feedingTask.selectedEmployee= employee;
        }
    }
}
