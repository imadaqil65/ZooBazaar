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
    public partial class EmployeeSelectControl : UserControl
    {
        Employee employee;
        ModifyFeedingTask modifyFeedingTask;
        public EmployeeSelectControl(Employee employee_ , ModifyFeedingTask modifyfeedingtask)
        {
            InitializeComponent();
            employee = employee_;
            modifyFeedingTask = modifyfeedingtask;
            lblEmpName.Text = $"{employee.FirstName} {employee.LastName}";
            lblDeparment.Text = $"Dep: {employee.Job}";
            DateTime birthdate = employee.BirthDate;
            lblDateOfBirth.Text = $"DoB: {birthdate.ToShortDateString()}";
        }

        private void EmployeeSelectControl_Click(object sender, EventArgs e)
        {
            SetSelectedControl();
        }

        private void lblEmpName_Click(object sender, EventArgs e)
        {
            SetSelectedControl();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SetSelectedControl();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SetSelectedControl();
        }

        private void lblDeparment_Click(object sender, EventArgs e)
        {
            SetSelectedControl();
        }

        private void lblDateOfBirth_Click(object sender, EventArgs e)
        {
            SetSelectedControl();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SetSelectedControl();
        }
        private void SetSelectedControl()
        {
            if (modifyFeedingTask.selectedEmployeeSelectControl != null)
            {
                modifyFeedingTask.selectedEmployeeSelectControl.BackColor = Color.DarkGray;
            }
            modifyFeedingTask.RememberSelectedEmployeeSelectControl(this);
            modifyFeedingTask.selectedEmployeeSelectControl.BackColor = Color.LimeGreen;
            modifyFeedingTask.selectedEmployee = employee;
        }
    }
}
