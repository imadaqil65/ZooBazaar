using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.User;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Logic.Services.User;
using zooproject.Domain.Domain.Security;
using System.Text.RegularExpressions;
using Domain.Domain.Enums;
using Domain.Domain.Misc;

namespace zooproject
{
    public partial class ReinstateEmployee : Form
    {
        Employee selectedEmployee;
        RemovedEmployee removedemployee;
        EmployeeManager employeeManager;
        EmployeeManager removalManager;
        public ReinstateEmployee(RemovedEmployee removedemployee, Employee selectedEmployee)
        {
            InitializeComponent();
            this.selectedEmployee = selectedEmployee;
            this.removedemployee = removedemployee;
            employeeManager = new EmployeeManager(new DBEmployees());
            removalManager = new EmployeeManager(new RemoveEmployeeDB());
            GenderCmbx.DataSource = Enum.GetValues(typeof(Gender));
            DepCmbx.DataSource = Enum.GetValues(typeof(JobType));
            RankCmbBx.DataSource = Enum.GetValues(typeof(Rank));
            ContractTypeCmbx.DataSource = Enum.GetValues(typeof(WorkContract));
            FillEmployeeDetails(selectedEmployee);
        }

        internal void FillEmployeeDetails(Employee emp)
        {
            selectedEmployee = emp;
            FNameTxtBx.Text = selectedEmployee.FirstName;
            LNameTxtBx.Text = selectedEmployee.LastName;
            UNameTxtBx.Text = selectedEmployee.Username;
            //PwdTxtBx.Text = selectedEmployee.Password;
            PhoneTxtBx.Text = selectedEmployee.PhoneNumber.ToString();
            MailTxtBx.Text = selectedEmployee.Email;
            SpecRchTxtBx.Text = selectedEmployee.Specialication;
            if (selectedEmployee.EndDate != null)
            {
                EndDate.Value = (DateTime)selectedEmployee.EndDate;
            }
            dtpBirthdate.Value = selectedEmployee.BirthDate;
            BsnTxtBx.Text = selectedEmployee.BSN.ToString();
            DepCmbx.SelectedItem = selectedEmployee.Job;
            GenderCmbx.SelectedItem = selectedEmployee.UserGender;
            RankCmbBx.SelectedItem = selectedEmployee.UserRank;
        }

        private void UserCredentials(string[] strings)
        {
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (strings.Any(x => string.IsNullOrEmpty(x.ToString())))
            {
                MessageBox.Show("Some fields are empty. Please try again");
                return;
            }

            if (!Regex.IsMatch(strings[4], pattern))
            {
                MessageBox.Show("Enter a valid email address");
                return;
            }
        }
        private void CheckDigit(string textbox1, string textbox2)
        {
            bool intPhone = textbox1.All(char.IsDigit);
            bool intBsn = textbox2.All(char.IsDigit);

            if (intPhone == false || intBsn == false)
            {
                MessageBox.Show("The phone and Bsn field only accepts numbers");
                return;
            }
        }

        private void ReinstateEmployeeBtn_Click(object sender, EventArgs e)
        {
            string? firstName = FNameTxtBx.Text;
            string? lastName = LNameTxtBx.Text;
            string? userName = UNameTxtBx.Text;
            string? password = Hash.HashPassword(PwdTxtBx.Text);
            string? email = MailTxtBx.Text;
            string? specialication = SpecRchTxtBx.Text;

            var strings = new[] { firstName, lastName, userName, password, email };

            UserCredentials(strings);
            CheckDigit(PhoneTxtBx.Text, BsnTxtBx.Text);

            int phone = Convert.ToInt32(PhoneTxtBx.Text);
            int BSN = (int)Convert.ToInt64(BsnTxtBx.Text);
            DateTime startDate = StartDate.Value.Date;
            DateTime birthDate = dtpBirthdate.Value.Date;
            //DateTime endDate = EndDate.Value.Date;
            int contracthours = ContractCalculator.CalculateFTE(contracthoursNUD.Value);
            WorkContract workContract;
            Enum.TryParse<WorkContract>(ContractTypeCmbx.SelectedValue.ToString(), out workContract);
            Gender gender;
            Enum.TryParse<Gender>(GenderCmbx.SelectedValue.ToString(), out gender);
            JobType jobType;
            Enum.TryParse<JobType>(DepCmbx.SelectedValue.ToString(), out jobType);
            Rank rank;
            Enum.TryParse<Rank>(RankCmbBx.SelectedValue.ToString(), out rank);
            DateTime? endDate; if (workContract == WorkContract.temporary) { endDate = EndDate.Value.Date; }
            else { endDate = null; }

            employeeManager.CreateEmployee(jobType, rank, startDate, endDate, firstName, lastName,
            gender, email, userName, password, birthDate, phone, BSN, specialication, contracthours, workContract);
            removalManager.RemoveEmployee(selectedEmployee);

            MessageBox.Show("Employee succsessfully added");

            FNameTxtBx.Clear();
            LNameTxtBx.Clear();
            UNameTxtBx.Clear();
            PwdTxtBx.Clear();
            MailTxtBx.Clear();
            SpecRchTxtBx.Clear();
            PhoneTxtBx.Clear();
            BsnTxtBx.Clear();
        }

        private void ReinstateEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            removedemployee.Show(); //this.Hide();
        }

        private void ContractTypeCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContractTypeCmbx.SelectedIndex != 1)
            {
                label24.Hide();
                EndDate.Hide();
            }
            else 
            { 
                label24.Show(); EndDate.Show(); 
            }

            if (ContractTypeCmbx.SelectedIndex == 2)
            {
                label6.Visible = false; label1.Visible = false;
                contracthoursNUD.Visible = false;
            }
            else
            {
                label6.Visible = true; label1.Visible = true;
                contracthoursNUD.Visible = true;
            }
        }
    }
}
