using Domain.Domain.Feeding;
using Infrastructure.Databases.Feeding;
using Logic.Services.Zoo;
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
using zooproject.User_Controls;

namespace zooproject
{
    public partial class AddFeedingTask : Form
    {
        ExhibitManager exhibitManager;
        AnimalManager animalManager;
        FeedingManager feedingManager;
        public Animal selectedAnimal;
        public Exhibit selectedExhibit;
        public AddFeedingTask()
        {
            InitializeComponent();
            exhibitManager = new ExhibitManager(new ExhibitDB());
            animalManager = new AnimalManager(new AnimalDB());
            feedingManager = new FeedingManager(new FeedingDB());
            FillAnimalBox();
            FillExhibitBox();
        }

        #region Buttons
        private void btnReloadAnimal_Click(object sender, EventArgs e)
        {
            FillAnimalBox();
        }

        private void btnReloadExhibit_Click(object sender, EventArgs e)
        {
            FillExhibitBox();
        }
        
        #endregion

        #region FlowLayout
        private void FillExhibitBox()
        {
            flpAnimalExibits.Controls.Clear();
            foreach (var result in exhibitManager.ReadAllExhibits())
            {
                AnimalExhibitControl exhibitControl = new AnimalExhibitControl(result, this);
                flpAnimalExibits.Controls.Add(exhibitControl);
            }
        }
        private void FillAnimalBox()
        {
            flpAnimals.Controls.Clear();
            foreach (var result in animalManager.ReadAllAnimals())
            {
                RemovedAnimalControl exhibitControl = new RemovedAnimalControl(result, this);
                flpAnimals.Controls.Add(exhibitControl);
            }
        }

        #endregion

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            feedingManager.AddFeedingTask(new FeedingTask(selectedExhibit.Id, dtpDateTime.Value));
            //feedingManager.AddFeedingTask(new FeedingTask(selectedExhibit.Id, dtpDateTime.Value, selectedAnimal.IDAuto));
        }
    }
}
