using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Domain.Domain.FilterObjects;
using zooproject.Logic.Services.User;

namespace zooproject
{
    public partial class Home : Form
    {
        EmployeeManager employeeManager;
        public Home(EmployeeManager empMan)
        {
            InitializeComponent();
            HidePartOfUI();
            employeeManager = empMan;

            Object rm = Properties.Resources.ResourceManager.GetObject("ZooLogo");
            Bitmap bitMap = (Bitmap)rm;
            Image image = bitMap;
            pictureBox_ZooLogo.Image = image;
        }
        private void HidePartOfUI()
        {
            tabControl1.TabPages.Remove(tabPage_Gallery); //This is "hiding" the tabpage, it doesn't delete it, just removes it from the collection
        }
        private void Button_HomeForm_Employee_Click(object sender, EventArgs e)
        {
            Employees empForm = new Employees(employeeManager);
            empForm.StartPosition = FormStartPosition.Manual;
            empForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); empForm.Show();
        }

        private void button_Home_Animals_Click(object sender, EventArgs e)
        {
            Animals AnimalForm = new Animals(employeeManager);
            AnimalForm.StartPosition = FormStartPosition.Manual;
            AnimalForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); AnimalForm.Show();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
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
        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void button_TicketStatistics_Click(object sender, EventArgs e)
        {
            TicketStatistics ticketStatistics = new TicketStatistics();
            ticketStatistics.StartPosition = FormStartPosition.Manual;
            ticketStatistics.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); ticketStatistics.Show();
        }
    }
}