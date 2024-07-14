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

namespace zooproject.User_Controls
{
    public partial class ZoneControl : UserControl
    {
        Zone zone;
        Animals animals;
        public ZoneControl(Zone zone, Animals animals)
        {
            InitializeComponent();
            this.zone = zone;
            this.animals = animals;

            ZoneNameLabel.Text = zone.Name;

        }

        private void ZoneDetailsBtn_Click(object sender, EventArgs e)
        {
        }
    }
}
