using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Events;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.User;
using Domain.Domain.Enums;
using static zooproject.Events.EmployeeFilterEvent;

namespace zooproject
{
    public partial class EmployeeFilter : Form
    {
        int Formcheck;
        Employees employees;
        RemovedEmployee removedEmployee;
        EmployeeFilterEvent employeeFilterEvent = new EmployeeFilterEvent();

        public EmployeeFilter(Employees employees)
        {
            InitializeComponent();
            select_job.Hide();
            select_rank.Hide();
            select_contract.Hide();
            ActiveDate.Hide();
            this.employees = employees;
            Formcheck = 0;
            employeeFilterEvent.EmployeeEvent += new EmployeeFilterEventHandler(employees.ViewAllFilteredEmployee);
            FillComboBoxes();
        }

        public EmployeeFilter(RemovedEmployee removedEmployee)
        {
            InitializeComponent();
            label2.Hide(); select_job.Hide(); select_rank.Hide();
            select_contract.Hide(); cbx_Contract.Hide(); checkBox_Contract.Hide();
            label3.Hide(); checkBox_Active.Hide(); dtp_ActiveDate.Hide(); ActiveDate.Hide();
            this.removedEmployee = removedEmployee;
            Formcheck = 1;
            employeeFilterEvent.EmployeeEvent += new EmployeeFilterEventHandler(removedEmployee.UpdateFilteredEmployee);
            FillComboBoxes();
        }
        private void FillComboBoxes()
        {
            cbx_JobType.DataSource = Enum.GetValues(typeof(JobType));
            cbx_Rank.DataSource = Enum.GetValues(typeof(Rank));
            cbx_Contract.DataSource = Enum.GetValues(typeof(WorkContract));
        }

        private void checkBox_Job_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Job.Checked == true) { select_job.Show(); }
            else { select_job.Hide(); }
        }

        private void checkBox_Rank_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Rank.Checked == true) { select_rank.Show(); }
            else { select_rank.Hide(); }
        }

        private void checkBox_Contract_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Contract.Checked == true) { select_contract.Show(); }
            else { select_contract.Hide(); }
        }
        private void checkBox_Active_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Active.Checked == true) { ActiveDate.Show(); }
            else { ActiveDate.Hide(); }
        }

        private void btn_ApplyEmployeeFilter_Click(object sender, EventArgs e)
        {
            int Jobtype = -1;
            if(checkBox_Job.Checked == true) { Jobtype = Convert.ToInt32((JobType)cbx_JobType.SelectedItem); }
            int rank = -1;
            if (checkBox_Rank.Checked == true) { rank = Convert.ToInt32((Rank)cbx_Rank.SelectedItem); }
            int contract = -1;
            if(checkBox_Contract.Checked == true) { contract = Convert.ToInt32((WorkContract)cbx_Contract.SelectedItem); }
            bool Active = false; DateTime? date = null;
            if(checkBox_Active.Checked == true) { Active = true; date = dtp_ActiveDate.Value.Date; }

            employeeFilterEvent.SentFilteredEmployees(Jobtype, rank, contract, Active, date);
        }

        private void EmployeeFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (Formcheck)
            {
                case 0:
                    employees.employeeFilter = null; break;
                case 1: 
                    removedEmployee.employeeFilter = null; break;   
            }
        }
    }
}
