using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Enums;

using zooproject.Logic.Services.User;

using zooproject.User_Controls;
using zooproject.Domain.Domain.Security;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace zooproject
{
    public partial class Employees : Form
    {
        Employee selectedEmployee;
        EmployeeManager employeeManager;
        public Employees(EmployeeManager empMan)
        {
            InitializeComponent();
            GenderCmbx.DataSource = Enum.GetValues(typeof(Gender));
            DepartmentCmbx.DataSource = Enum.GetValues(typeof(JobType));
            RankCmbx.DataSource = Enum.GetValues(typeof(Rank));
            EditGenderCmbx.DataSource = Enum.GetValues(typeof(Gender));
            EditDepCmbx.DataSource = Enum.GetValues(typeof(JobType));
            /*EditPromoteCmbx.DataSource = Enum.GetValues(typeof(Rank));*/
            EditRankCmbBx.DataSource = Enum.GetValues(typeof(Rank));
            employeeManager = empMan;
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

            var strings = new[] {firstName, lastName, userName, password, email};

            UserCredentials(strings);

/*            if (strings.Any(x => string.IsNullOrEmpty(x.ToString()))){
                MessageBox.Show("Some fields are empty. Please try again");
                return;
            }

            if (!Regex.IsMatch(email, pattern))
            {
                MessageBox.Show("Enter a valid email address");
                return;
            }*/
/*            bool intPhone = PhoneTxtBx.Text.All(char.IsDigit);
            bool intBsn = BSNTxtBx.Text.All(char.IsDigit);

            if (intPhone == false || intBsn == false)
            {
                MessageBox.Show("The phone and Bsn field only accepts numbers");
                return;
            }*/

            CheckDigit(PhoneTxtBx.Text, BSNTxtBx.Text);

            int phone = Convert.ToInt32(PhoneTxtBx.Text);
            int BSN = (int)Convert.ToInt64(BSNTxtBx.Text);
            DateTime startDate = DateTime.Now.Date;
            DateTime birthDate = dtpAddBirthdate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;
            Gender gender;
            Enum.TryParse<Gender>(GenderCmbx.SelectedValue.ToString(), out gender);
            JobType jobType;
            Enum.TryParse<JobType>(DepartmentCmbx.SelectedValue.ToString(), out jobType);
            Rank rank;
            Enum.TryParse<Rank>(RankCmbx.SelectedValue.ToString(), out rank);

            employeeManager.CreateEmployee(jobType, rank, startDate, firstName, lastName, 
            gender, email, userName, password, birthDate, phone, BSN, specialication);

            List<Employee> AddedEmps = new List<Employee>();
            Employee newEmp = employeeManager.GetLastAddedEmployee();
            AddedEmps.Add(newEmp);

            flowLayoutPanel_AddedEmployees.Controls.Clear();
            foreach (var Emp in AddedEmps)
            {
                EmployeeControl emp = new EmployeeControl(Emp, this);
                flowLayoutPanel_AddedEmployees.Controls.Add(emp);

            }
            MessageBox.Show("Employee succsessfully added");
        }

        /*        private void SelectedEmployee(Employee emp)
                {

                }*/
        internal void FillEmployeeDetails(Employee emp)
        {
            selectedEmployee = emp;
            EditFNameTxtBx.Text = selectedEmployee.FirstName;
            EditLNameTxtBx.Text = selectedEmployee.LastName;
            EditUNameTxtBx.Text = selectedEmployee.Username;
            EditPwdTxtBx.Text = selectedEmployee.Password;
            EditPhoneTxtBx.Text = selectedEmployee.PhoneNumber.ToString();
            EditMailTxtBx.Text = selectedEmployee.Email;
            EditSpecRchTxtBx.Text = selectedEmployee.Specialication;
            EditStartDate.Value = selectedEmployee.StartDate;
            /*            EditEndDate.Value = selectedEmployee.EndDate;*/
            dtpEditBirthdate.Value = selectedEmployee.BirthDate;
            EditBsnTxtBx.Text = selectedEmployee.BSN.ToString();
            EditDepCmbx.SelectedItem = selectedEmployee.Job;
            EditGenderCmbx.SelectedItem = selectedEmployee.UserGender;
            EditRankCmbBx.SelectedItem = selectedEmployee.UserRank;
/*            SelectedEmployee(selectedEmployee);*/
        }
        internal void EmptyEmployeeDetails()
        {
            EditFNameTxtBx.Text = "";
            EditLNameTxtBx.Text = "";
            EditUNameTxtBx.Text = "";
            EditPwdTxtBx.Text = "";
            EditPhoneTxtBx.Text =  "";
            EditMailTxtBx.Text = "";
            EditSpecRchTxtBx.Text = "";
            EditStartDate.Value = DateTime.Now.Date;
            dtpEditBirthdate.Value = DateTime.Now.Date;
            EditBsnTxtBx.Text = "";
            EditGenderCmbx.DataSource = Enum.GetValues(typeof(Gender));
            EditDepCmbx.DataSource = Enum.GetValues(typeof(JobType));
            EditRankCmbBx.DataSource = Enum.GetValues(typeof(Rank));
        }

        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_EditEmployees.Controls.Clear();

            Employee? searchedEmp = employeeManager.CheckEmployee(EmployeeSearchTxtBx.Text);

            if (searchedEmp == null)
            {
                MessageBox.Show("User not found");
                return;
            }

            EmployeeControl emp = new EmployeeControl(searchedEmp, this);
            flowLayoutPanel_EditEmployees.Controls.Add(emp);
        }

        private void ViewAllEmployeesBtn_Click(object sender, EventArgs e)
        {
            List<Employee> results = new List<Employee>();
            flowLayoutPanel_EditEmployees.Controls.Clear();
            foreach (var result in employeeManager.GetEmployees())
            {
                EmployeeControl emp = new EmployeeControl(result, this);
                flowLayoutPanel_EditEmployees.Controls.Add(emp);
            }
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
           switch (MessageBox.Show(this, "Are you sure you want to remove this employee?", "Removing Employee",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes: 
                    employeeManager.RemoveEmployee(selectedEmployee);
                    List<Employee> results = new List<Employee>();
                    flowLayoutPanel_EditEmployees.Controls.Clear();
                    foreach (var result in employeeManager.GetEmployees())
                    {
                        EmployeeControl emp = new EmployeeControl(result, this);
                        flowLayoutPanel_EditEmployees.Controls.Add(emp);
                    }
                        EmptyEmployeeDetails();  break;
                case DialogResult.No: break;
            }
        }

        private void EditEmployeeBtn_Click(object sender, EventArgs e)
        {
            selectedEmployee.FirstName = EditFNameTxtBx.Text.ToString();
            selectedEmployee.LastName = EditLNameTxtBx.Text.ToString();
            selectedEmployee.UserGender = (Gender)EditGenderCmbx.SelectedItem;
            selectedEmployee.BirthDate = dtpEditBirthdate.Value;
            selectedEmployee.BSN = Convert.ToInt32(EditBsnTxtBx.Text.Trim());
            selectedEmployee.Job = (JobType)EditDepCmbx.SelectedItem;
            selectedEmployee.UserRank = (Rank)EditRankCmbBx.SelectedItem;
            selectedEmployee.Specialication = EditSpecRchTxtBx.Text.ToString();
            selectedEmployee.Email = EditMailTxtBx.Text.ToString().Trim();
            selectedEmployee.PhoneNumber = Convert.ToInt32(EditPhoneTxtBx.Text.Trim());
            selectedEmployee.Username = EditUNameTxtBx.Text.ToString().Trim();
            selectedEmployee.Password = EditPwdTxtBx.Text.ToString().Trim();
            selectedEmployee.StartDate = EditStartDate.Value;
            selectedEmployee.EndDate = EditEndDate.Value;

            employeeManager.UpdateEmployeeData(selectedEmployee);
            MessageBox.Show("Succsefully edited");
        }
        private void button_Employees_Home_Click(object sender, EventArgs e)
        {
            Home HomeForm = new Home(employeeManager);
            this.Hide(); HomeForm.Show();
        }

        private void button_Employees_Animals_Click(object sender, EventArgs e)
        {
            Animals AnimalForm = new Animals(employeeManager);
            this.Hide(); AnimalForm.Show();
        }

        private void Employees_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                switch (MessageBox.Show(this, "Close Application?", "Closing",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes: Application.Exit(); break;
                    case DialogResult.No: e.Cancel = true; break;
                }
            }
        }
        private void Employees_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button_Employees_Logout_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Want To Logout?", "Logging Out",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Login LoginForm = new Login();
                    LoginForm.Show(); this.Hide(); ; break;
                case DialogResult.No: break;
            }
        }

        private void EmployeeSearchTxtBx_TextChanged(object sender, EventArgs e)
        {
            EmployeeSearchTxtBx.Refresh();
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            AddEmployeeItems(data);
            EmployeeSearchTxtBx.AutoCompleteCustomSource = data;
        }

        private void AddEmployeeItems(AutoCompleteStringCollection col)
        {
            foreach (var emp in employeeManager.GetEmployees())
            {
                col.Add(emp.FirstName);
            }
        }

        private void CreateAssignmentButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("it works");
        }

        private void button_Employees_Exhibits_Click(object sender, EventArgs e)
        {
            Exhibits ExhibitsForm = new Exhibits();
            this.Hide(); ExhibitsForm.Show();
        }

        private void button_Zones_Click(object sender, EventArgs e)
        {
            Zones ZonesForm = new Zones();
            this.Hide(); ZonesForm.Show();
        }

        private void button_ZooPartner_Click(object sender, EventArgs e)
        {
            ZooPartnerForm zooPartnerForm = new ZooPartnerForm();
            this.Hide(); zooPartnerForm.Show();
        }
    }
}
