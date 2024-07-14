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
    public partial class SelectZoneControl : UserControl
    {
        Zone zone;
        Exhibits exh;
        EditExhibit editEx;
        public SelectZoneControl(Zone zone, Exhibits exhibits)
        {
            InitializeComponent();
            this.zone = zone;
            this.exh = exhibits;
            lblName.Text = zone.Name;
        }
        public SelectZoneControl(Zone zone, EditExhibit editex)
        {
            InitializeComponent();
            this.zone = zone;
            this.editEx = editex;
            lblName.Text = zone.Name;
        }

        private void btnSelectClick(object sender, EventArgs e)
        {
            if(exh != null)
            {
                exh.selectedZone = zone;
            }
            if(editEx != null)
            {
                editEx.selectedZone = zone;
            }
        }
    }
}
