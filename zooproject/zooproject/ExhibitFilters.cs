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
using zooproject.Events;
using static zooproject.Events.ExhibitFilterEvent;
using zooproject.Logic.Services.Zoo;
using zooproject.Infrastructure.Databases.Zones;
using zooproject.Infrastructure.Databases.Exhibits;

namespace zooproject
{
    public partial class ExhibitFilters : Form
    {
        ExhibitFilterEvent exhibitFilterEvent = new ExhibitFilterEvent();
		Exhibits exhibits;
        MoveAnimal moveAnimal;
        ZoneManager zoneManager = new ZoneManager(new ZoneDB());
        public ExhibitFilters(Exhibits eXhibits)
        {
            InitializeComponent();
            HidePartOfUI();
            exhibits = eXhibits;
			comboBox_EnviromentType.DataSource = Enum.GetValues(typeof(EnviromentType));
            comboBox_EnviromentType.SelectedIndex = 0;
			exhibitFilterEvent.ExhibitEvent += new ExhibitFilterEventHandler(exhibits.UpdateExhibitsWithFilter);
            foreach (Zone zone in zoneManager.GetAllZones())
            {
                comboBox_Zone.Items.Add(zone);
            }
            comboBox_Zone.SelectedIndex = 0;
		}
        private void HidePartOfUI()
        {
            label_EnviromentSelected.Visible = false;
            label_ZoneSelected.Visible = false;
        }

        private void button_ApplyFilter_Click(object sender, EventArgs e)
        {
            int enviromentType = -1;
            if (checkBox_Enviroment.Checked == true)
            {
                enviromentType = Convert.ToInt32((EnviromentType)comboBox_EnviromentType.SelectedItem);
            }
            int zoneId = -1;
            if (checkBox_Zone.Checked == true)
            {
                Zone zone = (Zone)comboBox_Zone.SelectedItem;
                zoneId = zone.ZoneId;
            }
            int PreyPredator = -1;
            if (checkBox_Prey.Checked == true) { PreyPredator = 1; }
            else if (checkBox_Predetory.Checked == true) { PreyPredator = 0; }
            exhibitFilterEvent.SentFilteredExhibits(enviromentType, zoneId, PreyPredator);

        }
        private void checkBox_Predetory_Click(object sender, EventArgs e)
        {
            if (checkBox_Prey.CheckState == CheckState.Checked) { checkBox_Predetory.Checked = false; MessageBox.Show("Can't Select Prey And Predatory At The Same Time"); return; }
        }
        private void checkBox_Prey_Click(object sender, EventArgs e)
        {
            if (checkBox_Predetory.CheckState == CheckState.Checked) { checkBox_Prey.Checked = false; MessageBox.Show("Can't Select Prey And Predatory At The Same Time"); return; }
        }

        private void checkBox_Enviroment_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Enviroment.Checked == true) { label_EnviromentSelected.Visible = true; }
            if (checkBox_Enviroment.Checked == false) { label_EnviromentSelected.Visible = false; }
        }

        private void checkBox_Zone_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Zone.Checked == true) { label_ZoneSelected.Visible = true; }
            if (checkBox_Zone.Checked == false) { label_ZoneSelected.Visible = false; }
        }

        private void ExhibitFilters_FormClosing(object sender, FormClosingEventArgs e)
        {
            exhibits.exhibitFilters = null;
        }
    }
}
