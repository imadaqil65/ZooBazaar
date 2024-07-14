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
	public partial class AddAnimalSelectExhibitControl : UserControl
	{
		public AddAnimal addAnimal;
		Exhibit animalExhibit;
		ExhibitManager exhibitManager = new ExhibitManager(new ExhibitDB());
		public AddAnimalBasicInfoControl addAnimalBasicInfoControl;
		public AnimalExhibitControl selectedControl;
		public AddAnimalSelectExhibitControl(AddAnimal addanimal, AddAnimalBasicInfoControl addanimalbasicinfo)
		{
			InitializeComponent();
			addAnimal = addanimal;
			addAnimalBasicInfoControl = addanimalbasicinfo;
		}
		public void FillExhibitBox()
		{
			animalExhibit = null;
			flpAnimalExibits.Controls.Clear();
			flpExhibitAnimals.Controls.Clear();
			foreach (var result in exhibitManager.ReadAllExhibits())
			{
				if (addAnimalBasicInfoControl.checkBox_AddAnimal_Predatory.Checked == false && addAnimalBasicInfoControl.checkBox_AddAnimal_Prey.Checked == false)
				{
					if ((EnviromentType)addAnimalBasicInfoControl.comboBox_AddAnimal_EnviromentType.SelectedItem == result.ExhibitType)
					{
						AnimalExhibitControl exhibitControl = new AnimalExhibitControl(result, this);
						flpAnimalExibits.Controls.Add(exhibitControl);
					}
				}
				else if (addAnimalBasicInfoControl.checkBox_AddAnimal_Predatory.Checked == result.PredatorOrPrey)
				{
					if ((EnviromentType)addAnimalBasicInfoControl.comboBox_AddAnimal_EnviromentType.SelectedItem == result.ExhibitType)
					{
						AnimalExhibitControl exhibitControl = new AnimalExhibitControl(result, this);
						flpAnimalExibits.Controls.Add(exhibitControl);
					}
				}
			}
		}
		private void btnReloadExhibits_Click(object sender, EventArgs e)
		{
			FillExhibitBox();
		}
		public void RememberSelectedControl(AnimalExhibitControl animalexhibitcontrol)
		{
			selectedControl = animalexhibitcontrol;
		}
		public void AddAnimalsFromExhibit(List<Animal> animals)
		{
			flpExhibitAnimals.Controls.Clear();
			foreach (var result in animals)
			{
				AnimalDisplayControl animalDisplayControl = new AnimalDisplayControl(result, this);
				flpExhibitAnimals.Controls.Add(animalDisplayControl);
			}
		}
	}
}
