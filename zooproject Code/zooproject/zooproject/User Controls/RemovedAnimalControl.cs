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
    public partial class RemovedAnimalControl : UserControl
    {
        Animal animal;
        Animal scheduleAnimal;
        Animals animals;
        AddFeedingTask addFeeding;

        public RemovedAnimalControl(Animal exhibit, Animals animals)
        {
            InitializeComponent();
            this.animals = animals;
            this.animal = exhibit;

            lblName.Text = "Name: "+ animal.Name;
            lblSPecies.Text = "SPecies: "+animal.Species.ToString();
            lblAge.Text = "Age: " + Calculator.ToAge(animal.DateOfBirth).ToString();

        }
        public RemovedAnimalControl(Animal animal, AddFeedingTask animals)
        {
            InitializeComponent();
            this.addFeeding = animals;
            this.scheduleAnimal = animal;

            lblName.Text = this.scheduleAnimal.Name;
            lblSPecies.Text = this.scheduleAnimal.Species.ToString();
            lblAge.Text = Calculator.ToAge(this.scheduleAnimal.DateOfBirth).ToString();

        }
        private void btnSelectClick(object sender, EventArgs e)
        {
            if(animals == null)
            {

                addFeeding.selectedAnimal = scheduleAnimal;
            }
            animals.animalToBeRemoved = animal;
            MessageBox.Show("Animal Selected");
        }

       
    }
}
