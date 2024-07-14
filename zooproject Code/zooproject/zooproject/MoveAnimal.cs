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
    public partial class MoveAnimal : Form
    {
        Animals animalPage;
        Animal animal;
        Exhibit currentExhibit;
        ExhibitManager exhibitManager;
        AnimalManager animalManager;
        AnimalManager removedAnimalManager;
        private Exhibit animalExhibit;
        internal Animal animalToBeRemoved;

        public MoveAnimal(Animals AnimalsPage, Animal Animal)
        {
            InitializeComponent();
            animalPage = AnimalsPage;
            animal = Animal;
            animalToBeRemoved = Animal;
            exhibitManager = new ExhibitManager(new ExhibitDB());
            animalManager = new AnimalManager(new AnimalDB());
            removedAnimalManager = new AnimalManager(new RemovedAnimalDB());
            UpdateCurrentExhibit();
        }
        private void UpdateCurrentExhibit()
        {
            flowLayoutPanel2.Controls.Clear();
            currentExhibit = animalManager.GetExhibit(animal.exhibitID);
            if (currentExhibit != null)
            {
                CurrentExhibitControl currentExhibitControl = new CurrentExhibitControl(currentExhibit);
                flowLayoutPanel2.Controls.Add(currentExhibitControl);
            }
        }
        private void MoveRemoveAnimal_FormClosed(object sender, FormClosedEventArgs e)
        {
            animalPage.Show();
        }

        private void btnMoveAnimalExhibtiGettAll_Click(object sender, EventArgs e)
        {
            List<Animal> results = new List<Animal>();
            flpMoveAnimalsExhibit.Controls.Clear();
            foreach (var result in exhibitManager.ReadAllExhibits())
            {
                AnimalExhibitControl animalControl = new AnimalExhibitControl(result, this);
                flpMoveAnimalsExhibit.Controls.Add(animalControl);
            }
        }
        public void GetExhibit(Exhibit exhibit)
        {
            animalExhibit = exhibit;
            List<Animal> animals = animalManager.ReadByExhibit(animalExhibit);
            flowLayoutPanel_AnimalsInExhibit.Controls.Clear();
            foreach (Animal animal in animals)
            {
                AnimalDisplayControl animalControl = new AnimalDisplayControl(animal, this);
                flowLayoutPanel_AnimalsInExhibit.Controls.Add(animalControl);
            }
        }
        private void btnMoveAnimal_Click(object sender, EventArgs e)
        {
            if (chboxInternalMove.Checked)
            {
                animalToBeRemoved.exhibitID = animalExhibit.Id;
                animalManager.UpdateAnimal(animalToBeRemoved);
                UpdateCurrentExhibit();

            }
            else if (chBoxExternalMove.Checked)
            {
                animalToBeRemoved.exhibitID = animalExhibit.Id;
                animalToBeRemoved.LeavingDate = dtpMoveAnimalMovingDate.Value.Date;
                animalToBeRemoved.LeavingReason = rtxtBoxMoveAnimalMovingReason.Text;
                animalManager.RemoveAnimal(animalToBeRemoved);
                removedAnimalManager.CreateRemovedAnimal(animalToBeRemoved);
                UpdateCurrentExhibit();
            }
            MessageBox.Show("Animal Succesfully Moved");
        }
    }
}
