using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Infrastructure.Databases.Zones;
using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;

namespace zooproject
{
    public partial class Zones : Form
    {
        EmployeeManager employeeManager;
        ZoneManager zoneManager;
        public Zones()
        {
            InitializeComponent();
            employeeManager = new EmployeeManager(new DBEmployees());
            zoneManager = new ZoneManager(new ZoneDB());
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

        private void button_Exhibits_Exhibits_Click(object sender, EventArgs e)
        {
            Exhibits ExhibitsForm = new Exhibits();
            this.Hide(); ExhibitsForm.Show();
        }

        private void CreateZoneBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = ZoneNameTxtBx.Text.ToString();
                zoneManager.CreateZone(name);
                MessageBox.Show("Created Zone");
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); Console.WriteLine(ex); }
        }

        private void button_GetZones_Click(object sender, EventArgs e)
        {
            UpdateZones();
        }
        public void UpdateZones()
        {
            List<Domain.Domain.Zoo.Zone> zones = zoneManager.GetAllZones();
            flowLayoutPanel_Zones.Controls.Clear();
            foreach (var result in zoneManager.GetAllZones())
            {
                ModifyZoneControl modifyZoneControl = new ModifyZoneControl(result, this);
                flowLayoutPanel_Zones.Controls.Add(modifyZoneControl);
            }
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

        private void Zones_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Zones_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button_ZooPartner_Click(object sender, EventArgs e)
        {
            ZooPartnerForm zooPartnerForm = new ZooPartnerForm();
            this.Hide(); zooPartnerForm.Show();
        }
    }
}