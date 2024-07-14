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

        private void btnExhibitEdit_Click(object sender, EventArgs e)
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

        private void button_GetZones_Click(object sender, EventArgs e)
        {
            List<Zone> results = new List<Zone>();
            flowLayoutPanel_SelectZone.Controls.Clear();
            foreach (var result in zoneManager.GetAllZones())
            {
                SelectZoneControl selectZoneControl = new SelectZoneControl(result, this);
                flowLayoutPanel_SelectZone.Controls.Add(selectZoneControl);
            }
        }
        private void EditExhibit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exhibts.Show();
        }
    }
}
