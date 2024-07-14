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
using zooproject.Infrastructure.Databases.Zones;
using zooproject.Logic.Services.Zoo;

namespace zooproject
{
    public partial class ModifyZone : Form
    {
        Zone zone;
        Zones zones;
        ZoneManager zoneManager;
        public ModifyZone(Zone zOne, Zones zOnes)
        {
            InitializeComponent();
            zone = zOne;
            zones = zOnes;
            zoneManager = new ZoneManager(new ZoneDB());
        }

        private void EditZoneBtn_Click(object sender, EventArgs e)
        {
            string name = EditZoneNameTxtBx.Text.ToString();
            zone.Name = name;
            zoneManager.EditZone(zone);
            zones.Show();
            zones.UpdateZones();
            this.Close();
        }
        private void ModifyZone_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            zones.Show();

        }
    }
}
