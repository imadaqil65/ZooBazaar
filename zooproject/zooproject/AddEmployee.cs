using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.User_Controls;
using zooproject.Domain.Domain.Security;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Misc;
using zooproject.Logic.Services.User;
using System.Text.RegularExpressions;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Infrastructure.Databases.ZooPartners;
using zooproject.Logic.Services.Zoo;
using zooproject.Infrastructure.Databases.Employees;
using Domain.Domain.Enums;
using System.Diagnostics.Contracts;
using Domain.Domain.Misc;

namespace zooproject
{
    public partial class AddEmployee : Form
    {
        Employees Employeepage;
        //Employee selectedEmployee;
        EmployeeManager employeeManager;

        public AddEmployee(Employees employeepage)
        {
            InitializeComponent();
            GenderCmbx.DataSource = Enum.GetValues(typeof(Gender));
            DepartmentCmbx.DataSource = Enum.GetValues(typeof(JobType));
            RankCmbx.DataSource = Enum.GetValues(typeof(Rank));
            ContractTypeCmbx.DataSource = Enum.GetValues(typeof(WorkContract));
            Employeepage = employeepage;
            employeeManager = new EmployeeManager(new DBEmployees());
            //DemoButton.Hide();

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

        private void button_AddEmployee_Click(object sender, EventArgs e)
        {
            string? firstName = FirstNameTxtBx.Text;
            string? lastName = LastNameTxtBx.Text;
            string? userName = UsernameTxtBx.Text;
            string? password = Hash.HashPassword(PasswordTxtBx.Text);
            string? email = EmailTxtBx.Text;
            string? specialication = SpecialRichTxtBx.Text;

            var strings = new[] { firstName, lastName, userName, password, email, PhoneTxtBx.Text, BSNTxtBx.Text};

            UserCredentials(strings);
            CheckDigit(PhoneTxtBx.Text, BSNTxtBx.Text);
            int phone = Convert.ToInt32(PhoneTxtBx.Text);
            int BSN = (int)Convert.ToInt64(BSNTxtBx.Text);
            int contract = ContractCalculator.CalculateFTE(contracthoursNUD.Value);
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime birthDate = dtpAddBirthdate.Value.Date;
            WorkContract workContract;
            Enum.TryParse<WorkContract>(ContractTypeCmbx.SelectedValue.ToString(), out workContract);
            Gender gender;
            Enum.TryParse<Gender>(GenderCmbx.SelectedValue.ToString(), out gender);
            JobType jobType;
            Enum.TryParse<JobType>(DepartmentCmbx.SelectedValue.ToString(), out jobType);
            Rank rank;
            Enum.TryParse<Rank>(RankCmbx.SelectedValue.ToString(), out rank);
            DateTime? endDate; if (workContract == WorkContract.temporary) { endDate = dtpEndDate.Value.Date; }
            else { endDate = null; }

            employeeManager.CreateEmployee(jobType, rank, startDate, endDate, firstName, lastName,
            gender, email, userName, password, birthDate, phone, BSN, specialication, contract, workContract);

            MessageBox.Show("Employee succsessfully added");

            FirstNameTxtBx.Clear();
            LastNameTxtBx.Clear();
            UsernameTxtBx.Clear();
            PasswordTxtBx.Clear();
            EmailTxtBx.Clear();
            SpecialRichTxtBx.Clear();
            PhoneTxtBx.Clear();
            BSNTxtBx.Clear();
        }

        private void DemoButton_Click(object sender, EventArgs e)
        {
            FirstNameTxtBx.Text = "Riley";
            LastNameTxtBx.Text = "McArthur";
            UsernameTxtBx.Text = "r.mcarthur";
            PasswordTxtBx.Text = "arthuria";
            EmailTxtBx.Text = "r.mcarthur@hotmail.com";
            SpecialRichTxtBx.Text = "currency conversion";
            PhoneTxtBx.Text = "061231231";
            BSNTxtBx.Text = "892928371";
            DepartmentCmbx.Text = "Cashier";
            RankCmbx.Text = "Medior";
            dtpAddBirthdate.Value = new DateTime(2000, 02, 27);
            dtpEndDate.Value = DateTime.Now.AddYears(3);
        }

        private void AddEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            Counter.UpdateMoveModifyAnimalFormCounter();
        }

        private void ContractTypeCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ContractTypeCmbx.SelectedIndex != 1)
            {
                label19.Hide();
                dtpEndDate.Hide();
            }
            else { label19.Show(); dtpEndDate.Show(); }

            if(ContractTypeCmbx.SelectedIndex == 2)
            {
                label6.Visible = false; label8.Visible = false;
                contracthoursNUD.Value = 0;
                contracthoursNUD.Visible = false;
            }
            else
            {
                label6.Visible = true; label8.Visible = true;
                contracthoursNUD.Visible = true;
            }
        }
    }
}
