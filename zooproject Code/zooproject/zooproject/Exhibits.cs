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
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Infrastructure.Databases.Zones;
using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;

namespace zooproject
{
	public partial class Exhibits : Form
	{
        ExhibitManager exhibitManager;
        ZoneManager zoneManager;
        public Zone selectedZone;
        EmployeeManager employeeManager = new EmployeeManager(new DBEmployees());
        Exhibit animalExhibit;
        public Exhibits()
		{
			InitializeComponent();
            exhibitManager = new ExhibitManager(new ExhibitDB());
            zoneManager = new ZoneManager(new ZoneDB());
        }

        private void btnCreateExhibit_Click(object sender, EventArgs e)
        {
            string name = txtboxExhibitName.Text;
            bool predatorOrPrey = false;
            if (cboxExhibitPredator.Checked) { predatorOrPrey = true; }
            else if (cboxExhibitPrey.Checked) { predatorOrPrey = false; }
            EnviromentType enviromentType = (EnviromentType)cmboxExhibitType.SelectedItem;
            exhibitManager.CreateExhibit(name, predatorOrPrey, enviromentType);
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
            this.Hide(); HomeForm.Show();
        }

        private void button_Exhibits_Animals_Click(object sender, EventArgs e)
        {
            Animals AnimalForm = new Animals(employeeManager);
            this.Hide(); AnimalForm.Show();
        }

        private void Button_Exhibits_Employee_Click(object sender, EventArgs e)
        {
            Employees empForm = new Employees(employeeManager);
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
            List<Exhibit> results = new List<Exhibit>();
            flowLayoutPanel1.Controls.Clear();
            foreach (var result in exhibitManager.ReadAllExhibits())
            {
                ExhibitControl exhibitControl = new ExhibitControl(result, this);
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
            this.Hide(); ZonesForm.Show();
        }

        private void button_ZooPartner_Click(object sender, EventArgs e)
        {
            ZooPartnerForm zooPartnerForm = new ZooPartnerForm();
            this.Hide(); zooPartnerForm.Show();
        }
    }
}
