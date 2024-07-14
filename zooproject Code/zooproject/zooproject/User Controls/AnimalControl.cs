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
    public partial class AnimalControl : UserControl
    {
        Animal animal;
        Animals animalsPage;
        AnimalManager animalManager;
        public AnimalControl(Animal animal, Animals animals)
        {
            InitializeComponent();
            this.animal = animal;
            this.animalsPage = animals;
            animalManager = new AnimalManager(new AnimalDB());

            lblName.Text = animal.Name;
            lblSPecies.Text = animal.Species.ToString();
            lblAge.Text = Calculator.ToAge(animal.DateOfBirth).ToString();
        }

        private void DetailsClick(object sender, EventArgs e)
        {
            ModifyAnimal modifyAnimal = new ModifyAnimal(animalsPage, animal);
            animalsPage.Hide(); modifyAnimal.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveAnimal moveRemoveAnimal = new MoveAnimal(animalsPage, animal);
            animalsPage.Hide(); moveRemoveAnimal.Show();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure?", "Removing Animal",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    animalManager.RemoveAnimal(animal); animalsPage.UpdateAnimalControlAll(); break;
                case DialogResult.No: break;
            }
        }
    }
}
