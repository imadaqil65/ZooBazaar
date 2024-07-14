using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Logic.Services.User;
using zooproject.Domain.Domain.User;
using zooproject.User_Controls;
using zooproject.Infrastructure.Databases.Employees;
using Domain.Domain.Enums;
using System.Diagnostics.Contracts;
using zooproject.Events;
using static zooproject.Events.EmployeeFilterEvent;

namespace zooproject
{
    public partial class RemovedEmployee : Form
    {
        Employees employeepage;
        EmployeeManager removalmanager;
        EmployeeFilterEvent employeeFilterEvent;
        public EmployeeFilter? employeeFilter;

        public RemovedEmployee(Employees employeepage)
        {
            InitializeComponent();
            this.employeepage = employeepage;
            removalmanager = new EmployeeManager(new RemoveEmployeeDB());
            ViewAllEmployees();
        }

        private void ViewAllEmployees()
        {
            flp_TerminatedEmployee.Controls.Clear();
            foreach (var v in removalmanager.GetEmployees())
            {
                RemovedEmployeeControl e = new RemovedEmployeeControl(v, this);
                flp_TerminatedEmployee.Controls.Add(e);
            }
        }

        public void UpdateFilteredEmployee(int Jobtype, int Rank, int Workcontract, bool active, DateTime? date)
        {
            int job = Jobtype;
            int rank = Rank;

            List<Employee> employeeslist = removalmanager.GetEmployees();
            foreach (Employee emp in employeeslist.ToList())
            {
                if (job != -1 && (JobType)job != emp.Job)
                {
                    employeeslist.Remove(emp);
                }
                if (rank != -1 && (Rank)rank != emp.UserRank)
                {
                    employeeslist.Remove(emp);
                }
            }
            flp_TerminatedEmployee.Controls.Clear();
            foreach (Employee empl in employeeslist.ToList())
            {
                RemovedEmployeeControl e = new RemovedEmployeeControl(empl, this);
                flp_TerminatedEmployee.Controls.Add(e);
            }
        }

        private void SetFilterEvent()
        {
            employeeFilterEvent = new EmployeeFilterEvent();
            employeeFilterEvent.EmployeeEvent += new EmployeeFilterEventHandler(this.UpdateFilteredEmployee);
        }

        private void RemovedEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            employeepage.Show();
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            ViewAllEmployees();
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            if (employeeFilter == null)
            {
                employeeFilter = new EmployeeFilter(this);
                this.SetFilterEvent();
                employeeFilter.StartPosition = FormStartPosition.Manual;
                employeeFilter.Location = new Point(this.Location.X + 889, this.Location.Y);
                employeeFilter.Show();
            }
        }
    }
}
