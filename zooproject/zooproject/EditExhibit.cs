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
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Infrastructure.Databases.Zones;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;

namespace zooproject
{
    public partial class EditExhibit : Form
    {
        ExhibitManager exhibitManager;
        ZoneManager zoneManager;
        Exhibit selectedExhibit;
        Exhibits Exhibts;
        public Zone selectedZone;

        public SelectZoneControl selectedZoneControl;

		public EditExhibit(Exhibits exhibits, Exhibit exhibit)
        {
            exhibitManager = new ExhibitManager(new ExhibitDB());
            zoneManager = new ZoneManager(new ZoneDB());
            selectedExhibit = exhibit;
            Exhibts = exhibits;
            InitializeComponent();
            FillExhibitDetails();
        }
        public void FillExhibitDetails()
        {
            try
            {
                cmboxEditExhibitType.DataSource = Enum.GetValues(typeof(EnviromentType));
                txtboxEditExhibitName.Text = selectedExhibit.Name;
                cmboxEditExhibitType.SelectedItem = selectedExhibit.ExhibitType;
                if (selectedExhibit.PredatorOrPrey == true)
                {
                    chboxPredatorEditExhibit.Checked = true;
                    chboxPreyEditExhibit.Checked = false;
                }
                else if (selectedExhibit.PredatorOrPrey == false)
                {
                    chboxPredatorEditExhibit.Checked = false;
                    chboxPreyEditExhibit.Checked = true;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }

        private void button_GetZones_Click(object sender, EventArgs e)
        {
            try
            {
                List<Zone> results = new List<Zone>();
                flowLayoutPanel_SelectZone.Controls.Clear();
                foreach (var result in zoneManager.GetAllZones())
                {
                    SelectZoneControl selectZoneControl = new SelectZoneControl(result, this);
                    flowLayoutPanel_SelectZone.Controls.Add(selectZoneControl);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }
        private void EditExhibit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exhibts.Show();
        }

		private void btnExhibitEdit_Click_1(object sender, EventArgs e)
		{
            try
            {
                selectedExhibit.Name = txtboxEditExhibitName.Text;

                if (chboxPredatorEditExhibit.Checked) { selectedExhibit.PredatorOrPrey = true; }
                else if (chboxPreyEditExhibit.Checked) { selectedExhibit.PredatorOrPrey = false; }
                selectedExhibit.ExhibitType = (EnviromentType)cmboxEditExhibitType.SelectedItem;
                if (selectedZone == null) { selectedExhibit.ZoneId = selectedExhibit.ZoneId; }
                else if (selectedZone != null) { selectedExhibit.ZoneId = selectedZone.ZoneId; }
                exhibitManager.EditExhibit(selectedExhibit);
                MessageBox.Show("Succesfully Updated Exhibit");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }
    }
}
