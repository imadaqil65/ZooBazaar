using Logic.Services.Statistics;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Logic.Services.User;

namespace zooproject
{
    public partial class TicketStatistics : Form
    {
        EmployeeManager employeeManager;
        public TicketStatsCustomSelectionForm? ticketStatsCustomSelectionForm;
        public TicketStatistics()
        {
            InitializeComponent();
            employeeManager = new EmployeeManager(new DBEmployees());
            UpdateChart(DateTime.Now);
        }
        private void AddPointToChart(KeyValuePair<DayOfWeek, int> day, string chartseries)
        {
            switch (Convert.ToInt32(day.Key))
            {
                case 0:
                    chart_ticket_sales.Series[chartseries].Points.AddXY("Sunday", day.Value);
                    break;
                case 1:
                    chart_ticket_sales.Series[chartseries].Points.AddXY("Monday", day.Value);
                    break;
                case 2:
                    chart_ticket_sales.Series[chartseries].Points.AddXY("Tuesday", day.Value);
                    break;
                case 3:
                    chart_ticket_sales.Series[chartseries].Points.AddXY("Wednesday", day.Value);
                    break;
                case 4:
                    chart_ticket_sales.Series[chartseries].Points.AddXY("Thursday", day.Value);
                    break;
                case 5:
                    chart_ticket_sales.Series[chartseries].Points.AddXY("Friday", day.Value);
                    break;
                case 6:
                    chart_ticket_sales.Series[chartseries].Points.AddXY("Saturday", day.Value);
                    break;
            }
        }
        public void UpdateChart(DateTime date)
        {
            try
            {
                TicketStatisticsManager.GetTickets(date);
                chart_ticket_sales.Series.Clear();
                chart_ticket_sales.ChartAreas.Clear();
                chart_ticket_sales.ChartAreas.Add("TicketSaleChartArea");
                chart_ticket_sales.Series.Add("Ticket Sales");
                chart_ticket_sales.Series["Ticket Sales"].ChartArea = "TicketSaleChartArea";
                foreach (KeyValuePair<DayOfWeek, int> day in TicketStatisticsManager.GetAmountPerDay())
                {
                    AddPointToChart(day, "Ticket Sales");
                }
                chart_ticket_sales.ChartAreas.Add("UnusedTicketChartArea");
                chart_ticket_sales.Series.Add("Unused Tickets");
                chart_ticket_sales.Series["Unused Tickets"].ChartArea = "UnusedTicketChartArea";
                foreach (KeyValuePair<DayOfWeek, int> day in TicketStatisticsManager.GetUnusedTicketAmountPerDay())
                {
                    AddPointToChart(day, "Unused Tickets");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void button_current_Click(object sender, EventArgs e)
        {
            UpdateChart(DateTime.Now);
        }
        private void button_Last_Click(object sender, EventArgs e)
        {
            UpdateChart(DateTime.Now.AddDays(-7));
        }
        private void button_CustomDates_Click(object sender, EventArgs e)
        {
            if(ticketStatsCustomSelectionForm == null)
            {
                ticketStatsCustomSelectionForm = new TicketStatsCustomSelectionForm(this);
                ticketStatsCustomSelectionForm.StartPosition = FormStartPosition.Manual;
                ticketStatsCustomSelectionForm.Location = new Point(this.Location.X + 1163, this.Location.Y);
                ticketStatsCustomSelectionForm.Show();
            }
        }
        private void button_Home_LogOut_Click(object sender, EventArgs e)
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
        private void TicketStatistics_FormClosing(object sender, FormClosingEventArgs e)
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
        private void TicketStatistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Home HomeForm = new Home(employeeManager);
            HomeForm.StartPosition = FormStartPosition.Manual;
            HomeForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); HomeForm.Show();
        }
        private void button_Home_Animals_Click(object sender, EventArgs e)
        {
            Animals AnimalForm = new Animals(employeeManager);
            AnimalForm.StartPosition = FormStartPosition.Manual;
            AnimalForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); AnimalForm.Show();
        }
        private void Button_HomeForm_Employee_Click(object sender, EventArgs e)
        {
            Employees empForm = new Employees(employeeManager);
            empForm.StartPosition = FormStartPosition.Manual;
            empForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); empForm.Show();
        }

        private void button_Home_Exhibits_Click(object sender, EventArgs e)
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

        private void button_FeedingSchedule_Click(object sender, EventArgs e)
        {
            FeedingSchedule feedingSchedule = new FeedingSchedule();
            feedingSchedule.StartPosition = FormStartPosition.Manual;
            feedingSchedule.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); feedingSchedule.Show();
        }
    }
}