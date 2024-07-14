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
using zooproject.Infrastructure.Databases.ZooPartners;
using zooproject.Logic.Services.Zoo;

namespace zooproject.User_Controls
{
    public partial class ZooPartnerControl : UserControl
    {
        ZooPartner zooPartner;
        ZooPartnerManager zooPartnerManager;
        ZooPartnerForm zooPartnerForm;
        public ZooPartnerControl(ZooPartner zoopartner, ZooPartnerForm zoopartnerform)
        {
            InitializeComponent();
            zooPartner = zoopartner;
            zooPartnerForm  = zoopartnerform;
            label_SetName.Text = zooPartner.Name;
        }
        private void button_Select_Click(object sender, EventArgs e)
        {
            zooPartnerManager = new ZooPartnerManager(new DBZooPartner());
            zooPartnerManager.RemoveZooPartner(zooPartner);
            zooPartnerForm.LoadZooPartners();
        }
    }
}