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
using zooproject.Domain.Domain.Security;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;
using System.Text.RegularExpressions;
using Domain.Domain.Enums;
using Domain.Domain.Misc;

namespace zooproject
{
    public partial class ModifyEmployee : Form
    {
        Employee selectedEmployee;
        Employees employeePage;
        EmployeeManager employeeManager;
        EmployeeManager removedemployeemanager;
        EmployeeControl employeeControl;
        public ModifyEmployee(Employees employeePage, Employee employee, EmployeeControl employeeControl)
        {
            InitializeComponent();
            InstanciateObjects(employeePage, employee);
            FillComboBoxes();
            FillEmployeeDetails();
            this.employeeControl = employeeControl;
        }

        private void FillComboBoxes()
        {
            EditGenderCmbx.DataSource = Enum.GetValues(typeof(Gender));
            EditDepCmbx.DataSource = Enum.GetValues(typeof(JobType));
            EditRankCmbBx.DataSource = Enum.GetValues(typeof(Rank));
            ContractTypeCmbx.DataSource = Enum.GetValues(typeof(WorkContract));
        }

        private void InstanciateObjects(Employees employeePage, Employee employee)
        {
            this.employeePage = employeePage;
            selectedEmployee = employee;
            employeeManager = new EmployeeManager(new DBEmployees());
            removedemployeemanager = new EmployeeManager(new RemoveEmployeeDB());
        }

        private void FillEmployeeDetails()
        {
            EditFNameTxtBx.Text = selectedEmployee.FirstName;
            EditLNameTxtBx.Text = selectedEmployee.LastName;
            EditUNameTxtBx.Text = selectedEmployee.Username;
            //EditPwdTxtBx.Text = selectedEmployee.Password;
            EditPhoneTxtBx.Text = selectedEmployee.PhoneNumber.ToString();
            EditMailTxtBx.Text = selectedEmployee.Email;
            EditSpecRchTxtBx.Text = selectedEmployee.Specialication;
            EditStartDate.Value = selectedEmployee.StartDate;
            if (selectedEmployee.EndDate != null)
            {
                EditEndDate.Value = (DateTime)selectedEmployee.EndDate;
            }
            dtpEditBirthdate.Value = selectedEmployee.BirthDate;
            EditBsnTxtBx.Text = selectedEmployee.BSN.ToString();
            ContractTypeCmbx.SelectedItem = selectedEmployee.Workcontract;
            EditDepCmbx.SelectedItem = selectedEmployee.Job;
            EditGenderCmbx.SelectedItem = selectedEmployee.UserGender;
            EditRankCmbBx.SelectedItem = selectedEmployee.UserRank;
            contracthoursNUD.Value = ContractCalculator.TurnToDecimal(selectedEmployee.ContractHours);
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

        private void EditEmployeeBtn_Click(object sender, EventArgs e)
        {
            string? firstName = EditFNameTxtBx.Text.ToString();
            string? lastName = EditLNameTxtBx.Text.ToString();
            string? userName = EditUNameTxtBx.Text.ToString().Trim();
            string? password = Hash.HashPassword(EditPwdTxtBx.Text.ToString().Trim());
            string? email = EditMailTxtBx.Text.ToString().Trim();

            var strings = new[] { firstName, lastName, userName, password, email };

            UserCredentials(strings);
            CheckDigit(EditBsnTxtBx.Text, EditPhoneTxtBx.Text);

            selectedEmployee.FirstName = firstName;
            selectedEmployee.LastName = lastName;
            selectedEmployee.UserGender = (Gender)EditGenderCmbx.SelectedItem;
            selectedEmployee.BirthDate = dtpEditBirthdate.Value;
            selectedEmployee.BSN = Convert.ToInt32(EditBsnTxtBx.Text.Trim());
            selectedEmployee.Job = (JobType)EditDepCmbx.SelectedItem;
            selectedEmployee.UserRank = (Rank)EditRankCmbBx.SelectedItem;
            selectedEmployee.Specialication = EditSpecRchTxtBx.Text.ToString();
            selectedEmployee.ContractHours = ContractCalculator.CalculateFTE(contracthoursNUD.Value);
            selectedEmployee.Workcontract = (WorkContract)ContractTypeCmbx.SelectedItem;
            selectedEmployee.Email = email;
            selectedEmployee.PhoneNumber = Convert.ToInt32(EditPhoneTxtBx.Text.Trim());
            selectedEmployee.Username = userName;
            selectedEmployee.Password = password;
            selectedEmployee.StartDate = EditStartDate.Value;
            if(selectedEmployee.Workcontract == WorkContract.temporary) 
            { selectedEmployee.EndDate = EditEndDate.Value; }
            else { selectedEmployee.EndDate = null; }
            //selectedEmployee.EndDate = EditEndDate.Value;

            employeeManager.UpdateEmployeeData(selectedEmployee);
            MessageBox.Show("Successfully edited");
        }

        private void ModifyEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            employeePage.Show();
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            int id = selectedEmployee.Id;
            string FirstName = EditFNameTxtBx.Text;
            string LastName = EditLNameTxtBx.Text;
            Gender UserGender = (Gender)EditGenderCmbx.SelectedItem;
            DateTime BirthDate = dtpEditBirthdate.Value;
            int BSN = Convert.ToInt32(EditBsnTxtBx.Text.Trim());
            JobType Job = (JobType)EditDepCmbx.SelectedItem;
            Rank UserRank = (Rank)EditRankCmbBx.SelectedItem;
            string Specialication = EditSpecRchTxtBx.Text;
            string Email = EditMailTxtBx.Text.Trim();
            int PhoneNumber = Convert.ToInt32(EditPhoneTxtBx.Text.Trim());
            string Username = EditUNameTxtBx.Text.Trim();
            string Password = Hash.HashPassword(EditPwdTxtBx.Text.Trim());
            DateTime EndDate = EditEndDate.Value;
            bool IsFired; if (radioButton_Fired.Checked == true) { IsFired = true; } else { IsFired = false; }
            string LeaveReason = richTextBox_Edit_TerminationReason.Text;

            if (radioButton_Fired.Checked == true || radioButton_Retired.Checked == true && !string.IsNullOrEmpty(LeaveReason))
            {
                Employee removedemployee = new Employee(Job, UserRank, EndDate, id, FirstName, LastName, PhoneNumber,
                    UserGender, BSN, Email, Username, Password, BirthDate, Specialication, IsFired, LeaveReason);

                switch (MessageBox.Show(this, "Are you sure you want to remove this employee?", "Removing Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        removedemployeemanager.CreateRemovedEmployee(removedemployee);
                        employeeManager.RemoveEmployee(selectedEmployee);
                        MessageBox.Show("Employee Terminated");
                        employeePage.Show(); this.Close();
                        break;
                    case DialogResult.No: break;
                }
            }
            else
            {
                MessageBox.Show("Some fields are empty, please fill in to terminate employee");
            }
        }

        private void ModifyEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            employeeControl.modifyEmployee = null;
            employeeControl.BackColor = Color.CadetBlue;
            Counter.UpdateMoveModifyAnimalFormCounter();
        }

        private void ContractTypeCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContractTypeCmbx.SelectedIndex != 1)
            {
                label24.Hide();
                EditEndDate.Value = EditStartDate.Value.Date.AddYears(3);
                EditEndDate.Hide();
            }
            else { label24.Show(); EditEndDate.Show(); }

            if (ContractTypeCmbx.SelectedIndex == 2)
            {
                label2.Visible = false; label1.Visible = false;
                contracthoursNUD.Visible = false;
            }
            else
            {
                label2.Visible = true; label1.Visible = true;
                contracthoursNUD.Visible = true;
            }
        }
    }
}
