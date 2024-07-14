using Domain.Domain.Feeding;
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
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Logic.Services.Zoo;

namespace zooproject.User_Controls
{
    public partial class FeedingTaskControl : UserControl
    {
        FeedingTask feedingTask;
        Exhibit exhibit;
        Animal animal;
        FeedingSchedule feedingSchedule;
        ExhibitManager em;
        AnimalManager am;
        public FeedingTaskControl(FeedingTask feedingTask,FeedingSchedule feedingSchedule)
        {
            InitializeComponent();
            this.feedingTask = feedingTask;
            em = new ExhibitManager(new ExhibitDB());
            am = new AnimalManager(new AnimalDB());
            this.exhibit = em.GetByID(feedingTask.ExhibitID);
            this.animal = am.ReadByID(feedingTask.AnimalID);
            this.feedingSchedule = feedingSchedule;
            lblExhibit.Text = exhibit.Name;
        }
    }
}
