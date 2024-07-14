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
    public partial class CurrentExhibitControl : UserControl
    {
        Exhibit EXhibit;
        public CurrentExhibitControl(Exhibit exhibit)
        {
            InitializeComponent();
            EXhibit = exhibit;
            if (EXhibit != null) 
            {
                lblName.Text = EXhibit.Name;
                lblEnvironment.Text = exhibit.ExhibitType.ToString();
            }
        }
    }
}
