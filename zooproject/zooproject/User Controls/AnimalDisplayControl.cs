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

namespace zooproject.User_Controls
{
    public partial class AnimalDisplayControl : UserControl
    {
        Animal animal;
        Animals animals;
        MoveAnimal MRanimal;
        AddAnimal addAnimal;
        AddAnimalSelectExhibitControl animalSelectExhibitControl;
		public AnimalDisplayControl(Animal aNimal, Animals aNimals)
        {
            InitializeComponent();
            this.animal = aNimal;
            this.animals = aNimals;
            lblName.Text = animal.Name;
            lblSPecies.Text = animal.Species.ToString();
            lblAge.Text = Calculator.ToAge(animal.DateOfBirth).ToString();
        }
		public AnimalDisplayControl(Animal aNimal, AddAnimalSelectExhibitControl aNimals)
		{
			InitializeComponent();
			this.animal = aNimal;
			animalSelectExhibitControl = aNimals;
			lblName.Text = animal.Name;
			lblSPecies.Text = animal.Species.ToString();
			lblAge.Text = Calculator.ToAge(animal.DateOfBirth).ToString();
		}
		public AnimalDisplayControl(Animal aNimal, MoveAnimal mranimal) 
        {
            InitializeComponent();
            this.animal = aNimal;
            this.MRanimal = mranimal;
            lblName.Text = animal.Name;
            lblSPecies.Text = animal.Species.ToString();
            lblAge.Text = Calculator.ToAge(animal.DateOfBirth).ToString();
        }
        public AnimalDisplayControl(Animal aNimal, AddAnimal addanimal)
        {
            InitializeComponent();
            this.animal = aNimal;
            this.addAnimal = addanimal;
            lblName.Text = animal.Name;
            lblSPecies.Text = animal.Species.ToString();
            lblAge.Text = Calculator.ToAge(animal.DateOfBirth).ToString();
        }
    }
}
