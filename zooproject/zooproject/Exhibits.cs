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
using zooproject.Domain.Domain.FilterObjects;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Infrastructure.Databases.Zones;
using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;
using zooproject.Events;
using static zooproject.Events.ExhibitFilterEvent;

namespace zooproject
{
	public partial class Exhibits : Form
	{
        ExhibitFilterEvent exhibitFilterEvent = new ExhibitFilterEvent();

        ExhibitManager exhibitManager;
        ZoneManager zoneManager;
        public Zone selectedZone;
        EmployeeManager employeeManager = new EmployeeManager(new DBEmployees());
        Exhibit animalExhibit;
        public ExhibitFilters? exhibitFilters;

        public SelectZoneControl? selectedZoneControl;
        public Exhibits()
		{
			InitializeComponent();
            exhibitManager = new ExhibitManager(new ExhibitDB());
            zoneManager = new ZoneManager(new ZoneDB());
            cmboxExhibitType.DataSource = Enum.GetValues(typeof(EnviromentType));
            cmboxExhibitType.SelectedIndex = 0;
        }

        private void btnCreateExhibit_Click(object sender, EventArgs e)
        {
            string name = txtboxExhibitName.Text;
            bool predatorOrPrey = false;
            if (cboxExhibitPredator.Checked) { predatorOrPrey = true; }
            else if (cboxExhibitPrey.Checked) { predatorOrPrey = false; }
            EnviromentType enviromentType = (EnviromentType)cmboxExhibitType.SelectedItem;
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Name field was left empty!"); return; }
            if (cboxExhibitPredator.Checked == false && cboxExhibitPrey.Checked == false) { MessageBox.Show("Predator or Prey was left unchecked!"); return; }
            if (selectedZone == null) { MessageBox.Show("No Zone Was Selected!"); return; }
            int zoneID = selectedZone.ZoneId;
            exhibitManager.CreateExhibit(name, predatorOrPrey, enviromentType, zoneID);
            MessageBox.Show("Succesfully Added Exhibit");
        }
        private void FillZonesExhibit()
        {
            flowLayoutPanel_SelectZone.Controls.Clear();
            foreach (var result in zoneManager.GetAllZones())
            {
                SelectZoneControl zoneControl = new SelectZoneControl(result, this);
                flowLayoutPanel_SelectZone.Controls.Add(zoneControl);
            }
        }
        private void button_GetAllZonesExhibit_Click(object sender, EventArgs e)
        {
            FillZonesExhibit();
        }

        private void button_Exhibit_Home_Click(object sender, EventArgs e)
        {
            Home HomeForm = new Home(employeeManager);
            HomeForm.StartPosition = FormStartPosition.Manual;
            HomeForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); HomeForm.Show();
        }

        private void button_Exhibits_Animals_Click(object sender, EventArgs e)
        {
            Animals AnimalForm = new Animals(employeeManager);
            AnimalForm.StartPosition = FormStartPosition.Manual;
            AnimalForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); AnimalForm.Show();
        }

        private void Button_Exhibits_Employee_Click(object sender, EventArgs e)
        {
            Employees empForm = new Employees(employeeManager);
            empForm.StartPosition = FormStartPosition.Manual;
            empForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); empForm.Show();
        }

        private void button_Exhibits_LogOut_Click(object sender, EventArgs e)
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

        private void Exhibits_FormClosing(object sender, FormClosingEventArgs e)
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
        private void Exhibits_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button_GetExhibits_Click(object sender, EventArgs e)
        {
            List<Exhibit> results = new List<Exhibit>();
            flowLayoutPanel1.Controls.Clear();
            foreach (var result in exhibitManager.ReadAllExhibits())
            {
                ExhibitControl exhibitControl = new ExhibitControl(result, this);
                flowLayoutPanel1.Controls.Add(exhibitControl);
            }
        }
        public void UpdateExhibits()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var result in exhibitManager.ReadAllExhibits())
            {
                ExhibitControl exhibitControl = new ExhibitControl(result, this);
                flowLayoutPanel1.Controls.Add(exhibitControl);
            }
        }
        public void UpdateExhibitsWithFilter(int exhibitType, int zoneID, int isPreyPredetory)
        {
            flowLayoutPanel1.Controls.Clear();
            List<Exhibit> exhibits = exhibitManager.ReadAllExhibits();

			foreach (var result in exhibits.ToList())
            {
                if (exhibitType != -1)
                {
                    if((EnviromentType)exhibitType != result.ExhibitType) 
                    {
						exhibits.Remove(result);
					}
				}
                if (zoneID != -1)
                {
                    if(zoneID != result.ZoneId)
                    {
						exhibits.Remove(result);
					}
				}
                if (isPreyPredetory != -1)
                {
                    if (isPreyPredetory == 0 && result.PredatorOrPrey != true)
                    {
						exhibits.Remove(result);
					}
                    else if (isPreyPredetory == 1 && result.PredatorOrPrey != false)
                    {
						exhibits.Remove(result);
					}
				} 
            }
            foreach (Exhibit exhibit in exhibits)
            {
                ExhibitControl exhibitControl = new ExhibitControl(exhibit, this);
                flowLayoutPanel1.Controls.Add(exhibitControl);
            }
        }
        internal void GetExhibit(Exhibit exhibit)
        {
            animalExhibit = exhibit;
            MessageBox.Show("Exhibit is selected");
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
        private void button_Filters_Click(object sender, EventArgs e)
        {
            if(exhibitFilters == null)
            {
                exhibitFilterEvent.ExhibitEvent += new ExhibitFilterEventHandler(this.UpdateExhibitsWithFilter);
                exhibitFilters = new ExhibitFilters(this);
                exhibitFilters.StartPosition = FormStartPosition.Manual;
                exhibitFilters.Location = new Point(this.Location.X + 695, this.Location.Y);
                exhibitFilters.Show();
            }
        }

        private void cboxExhibitPredator_Click(object sender, EventArgs e)
        {
            if (cboxExhibitPrey.CheckState == CheckState.Checked) { cboxExhibitPredator.Checked = true; cboxExhibitPrey.Checked = false; return; }
        }

        private void cboxExhibitPrey_Click(object sender, EventArgs e)
        {
            if (cboxExhibitPredator.CheckState == CheckState.Checked) { cboxExhibitPrey.Checked = true; cboxExhibitPredator.Checked = false; }
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