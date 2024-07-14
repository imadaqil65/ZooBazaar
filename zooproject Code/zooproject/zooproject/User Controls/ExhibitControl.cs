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
        }

        private void DetailsClick(object sender, EventArgs e)
        {
            EditExhibit editExhibit = new EditExhibit(ExHibits, exhibit);
            this.ExHibits.Hide(); editExhibit.Show();
        }

        private void button_RemoveExhibit_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure?", "Removing Exhibit",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    exhibitManager.DeleteExhibit(exhibit); ExHibits.UpdateExhibits(); break;
                case DialogResult.No: break;
            }
        }
    }
}
