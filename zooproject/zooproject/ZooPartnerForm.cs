using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Domain.Domain.Zoo;
using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Infrastructure.Databases.ZooPartners;
using zooproject.User_Controls;

namespace zooproject
{
    public partial class ZooPartnerForm : Form
    {
        EmployeeManager employeeManager;
        ZooPartnerManager zooPartnerManager;
        public ZooPartnerForm()
        {
            InitializeComponent();
            employeeManager = new EmployeeManager(new DBEmployees());
            zooPartnerManager = new ZooPartnerManager(new ZooPartnerDB());
        }

        private void ZooPartnerForm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void ZooPartnerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button_Animals_Home_Click(object sender, EventArgs e)
        {
            Home HomeForm = new Home(employeeManager);
            HomeForm.StartPosition = FormStartPosition.Manual;
            HomeForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); HomeForm.Show();
        }

        private void button_Animals_Employees_Click(object sender, EventArgs e)
        {
            Employees empForm = new Employees(employeeManager);
            empForm.StartPosition = FormStartPosition.Manual;
            empForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); empForm.Show();
        }

        private void button_Zones_Click(object sender, EventArgs e)
        {
            Zones ZonesForm = new Zones();
            ZonesForm.StartPosition = FormStartPosition.Manual;
            ZonesForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); ZonesForm.Show();
        }

        private void button_Animals_Exhibits_Click(object sender, EventArgs e)
        {
            Exhibits ExhibitsForm = new Exhibits();
            ExhibitsForm.StartPosition = FormStartPosition.Manual;
            ExhibitsForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); ExhibitsForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Animals AnimalForm = new Animals(employeeManager);
            AnimalForm.StartPosition = FormStartPosition.Manual;
            AnimalForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); AnimalForm.Show();
        }

        private void button_CreateZooPartner_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name.Text.ToString())) { MessageBox.Show("Name Was Empty"); return; }
            string name = textBox_Name.Text.ToString();
            ZooPartner zooPartner = new ZooPartner(name);
            zooPartnerManager.AddZooPartner(zooPartner);
            LoadZooPartners();
        }
        public void LoadZooPartners()
        {
            flowLayoutPanel_ZooPartners.Controls.Clear();
            foreach (ZooPartner zooPartner in zooPartnerManager.GetAllZooPartners())
            {
                ZooPartnerControl zooPartnerControl = new ZooPartnerControl(zooPartner, this);
                flowLayoutPanel_ZooPartners.Controls.Add(zooPartnerControl);
            }   
        }
        private void button_Load_Click(object sender, EventArgs e)
        {
            LoadZooPartners();
        }

        private void btnFeedingSchedule_Click(object sender, EventArgs e)
        {
            FeedingSchedule feedingSchedule = new FeedingSchedule();
            feedingSchedule.StartPosition = FormStartPosition.Manual;
            feedingSchedule.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); feedingSchedule.Show();
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