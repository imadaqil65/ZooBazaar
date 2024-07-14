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
using zooproject.Logic.Services.Zoo;
using zooproject.Infrastructure.Databases.Zones;

namespace zooproject.User_Controls
{
    public partial class ModifyZoneControl : UserControl
    {
        Zone zOne;
        Zones zOnes;
        ZoneManager zoneManager;
        public ModifyZoneControl(Zone zone, Zones zones)
        {
            InitializeComponent();
            zOne = zone;
            zOnes = zones;
            zoneManager = new ZoneManager(new ZoneDB());
            ZoneNameLabel.Text = zone.Name;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            ModifyZone modifyZone = new ModifyZone(zOne, zOnes);
            zOnes.Hide(); modifyZone.Show();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure?", "Removing Zone",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    zoneManager.RemoveZone(zOne); zOnes.UpdateZones(); break;
                case DialogResult.No: break;
            }
        }
    }
}
