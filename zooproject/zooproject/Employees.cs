using Domain.Domain.Enums;
using Domain.Domain.Exceptions;
using zooproject.Domain.Domain.User;
using zooproject.Events;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Logic.Services.User;
using zooproject.User_Controls;
using static zooproject.Events.EmployeeFilterEvent;

namespace zooproject
{
    public partial class Employees : Form
    {
        EmployeeManager employeeManager;
        EmployeeManager removedemployeemanager;
        EmployeeFilterEvent employeeFilterEvent;
        public EmployeeFilter? employeeFilter;

        public Employees(EmployeeManager empMan)
        {
            InitializeComponent();
            employeeManager = empMan;
            removedemployeemanager = new EmployeeManager(new RemoveEmployeeDB());
            ViewAllEmployees();
        }

        private void button_AddEmployee_Click(object sender, EventArgs e)
        {
            if (Counter.GetMoveModifyAnimalFormCounter() == 0)
            {
                Counter.UpdateMoveModifyAnimalFormCounter();
                AddEmployee addEmployee = new AddEmployee(this);
                addEmployee.Show();
            }
        }

        public void ViewAllFilteredEmployee(int Jobtype, int Rank, int Workcontract, bool isActive, DateTime? date)
        {
            int job = Jobtype;
            int rank = Rank;
            int contract = Workcontract;
            bool Active = isActive;
            DateTime? Activedate = date;
            List<Employee> employeeslist;

            if (Active == false) { employeeslist = employeeManager.GetEmployees(); }
            else { employeeslist = employeeManager.GetActiveEmployee((DateTime)Activedate); }

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
                if (contract != -1 && (WorkContract)contract != emp.Workcontract)
                {
                    employeeslist.Remove(emp);
                }
            }

            flowLayoutPanel_EditEmployees.Controls.Clear();
            foreach (Employee empl in employeeslist.ToList())
            {
                EmployeeControl e = new EmployeeControl(empl, this);
                flowLayoutPanel_EditEmployees.Controls.Add(e);
            }
        }

        private void btn_FIlter_Click(object sender, EventArgs e)
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

        private void SetFilterEvent()
        {
            employeeFilterEvent = new EmployeeFilterEvent();
            employeeFilterEvent.EmployeeEvent += new EmployeeFilterEventHandler(this.ViewAllFilteredEmployee);
        }

        private void ViewAllEmployeesBtn_Click(object sender, EventArgs e)
        {
            ViewAllEmployees();
        }

        private void ViewAllEmployees()
        {
            try
            {
                List<Employee> employeeslist = employeeManager.GetEmployees();
                flowLayoutPanel_EditEmployees.Controls.Clear();
                foreach (Employee emp in employeeslist)
                {
                    if(emp.EndDate != null && emp.EndDate == DateTime.Now)
                    {
                        Employee removedemployee = new Employee(emp.Job, emp.UserRank, (DateTime)emp.EndDate, emp.Id, emp.FirstName, emp.LastName, emp.PhoneNumber, emp.UserGender, emp.BSN, emp.Email, emp.Username, emp.Password, emp.BirthDate, emp.Specialication, true, "Contract Expired");
                        removedemployeemanager.CreateRemovedEmployee(removedemployee);
                        employeeManager.RemoveEmployee(emp);

                    }
                    if (emp.EndDate == null || emp.EndDate != DateTime.Now)
                    {
                        EmployeeControl e = new EmployeeControl(emp, this);
                        flowLayoutPanel_EditEmployees.Controls.Add(e);
                    }
                }
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
        }

        private void button_Employees_Home_Click(object sender, EventArgs e)
        {
            Home HomeForm = new Home(employeeManager);
            HomeForm.StartPosition = FormStartPosition.Manual;
            HomeForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); HomeForm.Show();
        }

        private void button_Employees_Animals_Click(object sender, EventArgs e)
        {
            Animals AnimalForm = new Animals(employeeManager);
            AnimalForm.StartPosition = FormStartPosition.Manual;
            AnimalForm.Location = new Point(this.Location.X, this.Location.Y);
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

        /*private void EmployeeSearchTxtBx_TextChanged(object sender, EventArgs e)
        {
            EmployeeSearchTxtBx.Refresh();
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            AddEmployeeItems(data);
            EmployeeSearchTxtBx.AutoCompleteCustomSource = data;
        }*/

        private void AddEmployeeItems(AutoCompleteStringCollection col)
        {
            foreach (var emp in employeeManager.GetEmployees())
            {
                col.Add(emp.FirstName);
            }
        }

        private void button_Employees_Exhibits_Click(object sender, EventArgs e)
        {
            Exhibits ExhibitsForm = new Exhibits();
            ExhibitsForm.StartPosition = FormStartPosition.Manual;
            ExhibitsForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); ExhibitsForm.Show();
        }

        private void button_Zones_Click(object sender, EventArgs e)
        {
            Zones ZonesForm = new Zones();
            ZonesForm.StartPosition = FormStartPosition.Manual;
            ZonesForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); ZonesForm.Show();
        }

        private void button_ZooPartner_Click(object sender, EventArgs e)
        {
            ZooPartnerForm zooPartnerForm = new ZooPartnerForm();
            zooPartnerForm.StartPosition = FormStartPosition.Manual;
            zooPartnerForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); zooPartnerForm.Show();
        }

        private void btnFeedingSchedule_Click(object sender, EventArgs e)
        {
            FeedingSchedule feedingSchedule = new FeedingSchedule();
            feedingSchedule.StartPosition = FormStartPosition.Manual;
            feedingSchedule.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); feedingSchedule.Show();
        }

        private void button_RemovedEmployee_Click(object sender, EventArgs e)
        {
            RemovedEmployee removedemployee = new RemovedEmployee(this);
            removedemployee.StartPosition = FormStartPosition.Manual;
            removedemployee.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); removedemployee.Show();
        }

        private void button_TicketStatistics_Click(object sender, EventArgs e)
        {
            TicketStatistics ticketStatistics = new TicketStatistics();
            ticketStatistics.StartPosition = FormStartPosition.Manual;
            ticketStatistics.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); ticketStatistics.Show();
        }
    }
}
