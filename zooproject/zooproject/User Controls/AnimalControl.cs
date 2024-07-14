using zooproject.Domain.Domain.FilterObjects;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Logic.Services.Zoo;

namespace zooproject.User_Controls
{
	public partial class AnimalControl : UserControl
	{
		Animal animal;
		Animals animalsPage;
		AnimalManager animalManager;
		public MoveAnimal? moveAnimal;
		public ModifyAnimal? modifyAnimal;

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

		private void EditClick(object sender, EventArgs e)
		{
			if (Counter.GetMoveModifyAnimalFormCounter() == 0)
			{
				Counter.UpdateMoveModifyAnimalFormCounter();
                this.BackColor = Color.LimeGreen;
                if (modifyAnimal == null)
                {
                    modifyAnimal = new ModifyAnimal(animalsPage, animal, this);
                    modifyAnimal.StartPosition = FormStartPosition.Manual;
                    modifyAnimal.Location = new Point(animalsPage.Location.X + 889, animalsPage.Location.Y);
                    modifyAnimal.Show();
                }
            }
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (Counter.GetMoveModifyAnimalFormCounter() == 0)
			{
                Counter.UpdateMoveModifyAnimalFormCounter();
                this.BackColor = Color.LimeGreen;
				if (moveAnimal == null)
				{
					moveAnimal = new MoveAnimal(animalsPage, animal, this);
					moveAnimal.StartPosition = FormStartPosition.Manual;
					moveAnimal.Location = new Point(animalsPage.Location.X + 889, animalsPage.Location.Y);
					moveAnimal.Show();
				}
			}
		}
	}
}
