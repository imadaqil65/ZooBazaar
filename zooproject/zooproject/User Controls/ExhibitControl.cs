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

namespace zooproject.User_Controls
{
    public partial class ExhibitControl : UserControl
    {
        Exhibit exhibit;
        Exhibits ExHibits;
        ExhibitManager exhibitManager = new ExhibitManager(new ExhibitDB());
        public ExhibitControl(Exhibit exhibit, Exhibits exhibits)
        {
            InitializeComponent();
            this.ExHibits = exhibits;
            this.exhibit= exhibit;

            lblName.Text = exhibit.Name;
            lblEnvironment.Text = exhibit.ExhibitType.ToString();
            ZoneManager zoneManager = new ZoneManager(new ZoneDB());
            Zone zone = zoneManager.GetZoneWithID(exhibit.ZoneId);
            label_zone.Text = zone.Name;
            if (exhibit.PredatorOrPrey == true) { label_PreyPredator.Text = "True"; }
            else { label_PreyPredator.Text = "False"; }
        }

        private void DetailsClick(object sender, EventArgs e)
        {
            EditExhibit editExhibit = new EditExhibit(ExHibits, exhibit);
            this.ExHibits.Hide(); editExhibit.Show();
        }

        private void button_RemoveExhibit_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Want to remove: " + exhibit.Name + " Exhibit?", "Removing Exhibit",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    exhibitManager.DeleteExhibit(exhibit); ExHibits.UpdateExhibits(); break;
                case DialogResult.No: break;
            }
        }
    }
}
