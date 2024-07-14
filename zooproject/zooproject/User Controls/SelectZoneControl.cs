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

		private void SelectZoneControl_Click(object sender, EventArgs e)
		{
			if (exh != null)
			{
				exh.selectedZone = zone;
				if (exh.selectedZoneControl != null)
				{
					exh.selectedZoneControl.BackColor = Color.DarkGray;
				}
				exh.selectedZoneControl = this;
				exh.selectedZoneControl.BackColor = Color.LimeGreen;

			}
			if (editEx != null)
			{
				editEx.selectedZone = zone;
				if (editEx.selectedZoneControl != null)
				{
					editEx.selectedZoneControl.BackColor = Color.DarkGray;
				}
				editEx.selectedZoneControl = this;
				editEx.selectedZoneControl.BackColor = Color.LimeGreen;
			}
		}

		private void lblName_Click(object sender, EventArgs e)
		{
			if (exh != null)
			{
				exh.selectedZone = zone;
				if (exh.selectedZoneControl != null)
				{
					exh.selectedZoneControl.BackColor = Color.DarkGray;
				}
				exh.selectedZoneControl = this;
				exh.selectedZoneControl.BackColor = Color.LimeGreen;

			}
			if (editEx != null)
			{
				editEx.selectedZone = zone;
				if (editEx.selectedZoneControl != null)
				{
					editEx.selectedZoneControl.BackColor = Color.DarkGray;
				}
				editEx.selectedZoneControl = this;
				editEx.selectedZoneControl.BackColor = Color.LimeGreen;
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{
			if (exh != null)
			{
				exh.selectedZone = zone;
				if (exh.selectedZoneControl != null)
				{
					exh.selectedZoneControl.BackColor = Color.DarkGray;
				}
				exh.selectedZoneControl = this;
				exh.selectedZoneControl.BackColor = Color.LimeGreen;

			}
			if (editEx != null)
			{
				editEx.selectedZone = zone;
				if (editEx.selectedZoneControl != null)
				{
					editEx.selectedZoneControl.BackColor = Color.DarkGray;
				}
				editEx.selectedZoneControl = this;
				editEx.selectedZoneControl.BackColor = Color.LimeGreen;
			}
		}
	}
}
