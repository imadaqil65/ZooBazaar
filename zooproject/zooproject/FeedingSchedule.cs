using Domain.Domain.Feeding;
using Infrastructure.Databases.Feeding;
using Logic.Services.Schedule;
using Logic.Services.Zoo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Domain.Domain.Zoo;
using zooproject.Events;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;

namespace zooproject
{
    public partial class FeedingSchedule : Form
    {
        TaskFilterEvent taskFilterEvent;
        FeedingManager fm;
        EmployeeManager employeeManager;
        AutomatedScheduleGenerator automatedScheduleGenerator;
        AnimalManager animalManager;
        public FeedingSchedule()
        {
            InitializeComponent();
            fm = new FeedingManager(new FeedingDB());
            employeeManager = new EmployeeManager(new DBEmployees());
            automatedScheduleGenerator = new AutomatedScheduleGenerator();
            animalManager = new AnimalManager(new AnimalDB());
            cbSpecies.DataSource = Enum.GetValues(typeof(AnimalSpecies));
        }
        // Button controls are in region
        #region Button Controls
        private void button_Feeding_Home_Click(object sender, EventArgs e)
        {
            Home HomeForm = new Home(employeeManager);
            HomeForm.StartPosition = FormStartPosition.Manual;
            HomeForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); HomeForm.Show();
        }

        private void button_AddTask_Click(object sender, EventArgs e)
        {
            AddFeedingTask addFeedingTask = new AddFeedingTask();
            addFeedingTask.Show();
        }

        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            List<FeedingTask> generatedTasks = automatedScheduleGenerator.GenerateTasks(dtpStart.Value.Date, dtpEnd.Value.Date, animalManager.GetAnimals());
            automatedScheduleGenerator.AssignEmployees(dtpStart.Value.Date, dtpEnd.Value.Date);
            FillDataView(fm.GetAllFeedingTasks(dtpStart.Value.Date, dtpEnd.Value.Date));
        }
        //TODO: Make Filters
        private void btnEditFilter_Click(object sender, EventArgs e)
        {
            FillDataView(fm.GetAllFeedingTasks(dtpFirstDay.Value.Date, dtpLastDay.Value.Date));
        }
        private void btnGenerateFiltered_Click(object sender, EventArgs e)
        {
            List<FeedingTask> generatedTasks = automatedScheduleGenerator.GenerateTasks(dtpStart.Value.Date, dtpEnd.Value.Date, animalManager.ReadBySpecies((AnimalSpecies)cbSpecies.SelectedValue));
            automatedScheduleGenerator.AssignEmployees(dtpStart.Value.Date, dtpEnd.Value.Date);
            FillDataView(fm.GetAllFeedingTasks(dtpStart.Value.Date, dtpEnd.Value.Date));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FillDataView(fm.GetFeedingTaskByDatesAndAnimal(dtpFirstDay.Value.Date, dtpLastDay.Value.Date, (AnimalSpecies)cbSpecies.SelectedIndex));
        }
        #endregion
        //Methods relating to the user controls are in the region
        #region User Control Methods
        private void ClearFlowLayout()
        {
            flpMonday.Controls.Clear();
            flpTuesday.Controls.Clear();
            flpWednesday.Controls.Clear();
            flpThursday.Controls.Clear();
            flpFriday.Controls.Clear();
            flpSaturday.Controls.Clear();
            flpSunday.Controls.Clear();
        }
        private void FillDataView(List<FeedingTask> results)
        {
            ClearFlowLayout();
            foreach (FeedingTask result in results)
            {
                switch (result.FeedingDate.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        flpMonday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Tuesday:
                        flpTuesday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Wednesday:
                        flpWednesday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Thursday:
                        flpThursday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Friday:
                        flpFriday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Saturday:
                        flpSaturday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Sunday:
                        flpSunday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    default:
                        // code block
                        break;
                }
            }
        }

        #endregion

        private void SetTaskFilterEvent()
        {
            taskFilterEvent = new TaskFilterEvent();
            //taskFilterEvent.taskEvent += new TaskFilterEvent.TaskFilterEventHandler(this.UpdateAnimalControlFiltered);
        }
        private void button_Feeding_Employees_Click(object sender, EventArgs e)
        {
            Employees empForm = new Employees(employeeManager);
            empForm.StartPosition = FormStartPosition.Manual;
            empForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); empForm.Show();
        }

        private void button_Feeding_Exhibits_Click(object sender, EventArgs e)
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

        private void FeedingSchedule_FormClosing(object sender, FormClosingEventArgs e)
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
        private void FeedingSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button_Feeding_Animals_Click(object sender, EventArgs e)
        {
            Animals AnimalForm = new Animals(employeeManager);
            AnimalForm.StartPosition = FormStartPosition.Manual;
            AnimalForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); AnimalForm.Show();
        }
        private void button_Animals_Logout_Click(object sender, EventArgs e)
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

        private void button_TicketStatistics_Click(object sender, EventArgs e)
        {
            TicketStatistics ticketStatistics = new TicketStatistics();
            ticketStatistics.StartPosition = FormStartPosition.Manual;
            ticketStatistics.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); ticketStatistics.Show();
        }
    }
}