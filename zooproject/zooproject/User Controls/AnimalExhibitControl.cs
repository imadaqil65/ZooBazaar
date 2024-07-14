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
using zooproject.Infrastructure.Databases.Zones;
using zooproject.Logic.Services.Zoo;

namespace zooproject.User_Controls
{
    public partial class AnimalExhibitControl : UserControl
    {
        Animals aNimals;
        Exhibit exhibit;
        Exhibits ExHibits;
        EditExhibit editExhibit;
        AddAnimal addAnimal;
        MoveAnimal mranimals;
        AddFeedingTask feedingSchedule;
		AddAnimalSelectExhibitControl addAnimalSelectExhibitControl;
		AnimalManager animalManager;
        public AnimalExhibitControl(Exhibit eXhibit, MoveAnimal animals)
        {
            InitializeComponent();
            this.mranimals = animals;
            this.exhibit = eXhibit;

            lblName.Text = exhibit.Name;
            lblEnvironment.Text = exhibit.ExhibitType.ToString();
			ZoneManager zoneManager = new ZoneManager(new ZoneDB());
			Zone zone = zoneManager.GetZoneWithID(exhibit.ZoneId);
			label_Zone.Text = zone.Name;
			if (exhibit.PredatorOrPrey == true) { label_PreyPredator.Text = "True"; }
            else { label_PreyPredator.Text = "False"; }

        }

        public AnimalExhibitControl(Exhibit eXhibit, AddFeedingTask feedingSchedule)
        {
            InitializeComponent();
            animalManager = new AnimalManager(new AnimalDB());
            exhibit = eXhibit;
            this.feedingSchedule = feedingSchedule;
            lblName.Text = exhibit.Name;
            lblEnvironment.Text = exhibit.ExhibitType.ToString();
			ZoneManager zoneManager = new ZoneManager(new ZoneDB());
			Zone zone = zoneManager.GetZoneWithID(exhibit.ZoneId);
			label_Zone.Text = zone.Name;
			if (exhibit.PredatorOrPrey == true) { label_PreyPredator.Text = "True"; }
            else { label_PreyPredator.Text = "False"; }
        }
		public AnimalExhibitControl(Exhibit eXhibit, AddAnimalSelectExhibitControl addanimalselectexhibitcontrol)
		{
			InitializeComponent();
			animalManager = new AnimalManager(new AnimalDB());
			exhibit = eXhibit;
			addAnimalSelectExhibitControl = addanimalselectexhibitcontrol;
			lblName.Text = exhibit.Name;
			lblEnvironment.Text = exhibit.ExhibitType.ToString();
			ZoneManager zoneManager = new ZoneManager(new ZoneDB());
			Zone zone = zoneManager.GetZoneWithID(exhibit.ZoneId);
			label_Zone.Text = zone.Name;
			if (exhibit.PredatorOrPrey == true) { label_PreyPredator.Text = "True"; }
			else { label_PreyPredator.Text = "False"; }
		}
		private void AnimalExhibitControl_Click(object sender, EventArgs e)
		{
			SetSelectedControl();
		}

		private void label2_Click(object sender, EventArgs e)
		{
			SetSelectedControl();
		}

		private void lblName_Click(object sender, EventArgs e)
		{
			SetSelectedControl();
		}

		private void label1_Click(object sender, EventArgs e)
		{
			SetSelectedControl();
		}

		private void label_Zone_Click(object sender, EventArgs e)
		{
			SetSelectedControl();
		}

		private void label3_Click(object sender, EventArgs e)
		{
			SetSelectedControl();
		}

		private void lblEnvironment_Click(object sender, EventArgs e)
		{
			SetSelectedControl();
		}

		private void label4_Click(object sender, EventArgs e)
		{
			SetSelectedControl();
		}

		private void label_PreyPredator_Click(object sender, EventArgs e)
		{
			SetSelectedControl();
		}
		private void SetSelectedControl()
		{
			if (mranimals != null)
			{
				mranimals.GetExhibit(exhibit);
				if (mranimals.selectedControl != null)
				{
					mranimals.selectedControl.BackColor = Color.DarkGray;
				}
				mranimals.RememberSelectedControl(this);
				mranimals.selectedControl.BackColor = Color.LimeGreen;
			}
			if (aNimals != null)
			{
				aNimals.animalExhibit = exhibit;
			}
			if (feedingSchedule != null)
			{
				feedingSchedule.selectedExhibit = exhibit;
				if (feedingSchedule.selectedAnimalExhibitControl != null)
				{
					feedingSchedule.selectedAnimalExhibitControl.BackColor = Color.DarkGray;
				}
				feedingSchedule.RememberSelectedAnimalExhibitControl(this);
				feedingSchedule.selectedAnimalExhibitControl.BackColor = Color.LimeGreen;
				
			}
			if (addAnimalSelectExhibitControl != null)
			{
				if (addAnimalSelectExhibitControl.addAnimalBasicInfoControl.CheckIfPreyPredatoryCheckBoxesAreChecked())
				{
					List<Animal> animalslist = animalManager.ReadByExhibit(exhibit);
					addAnimalSelectExhibitControl.AddAnimalsFromExhibit(animalslist);
					addAnimalSelectExhibitControl.addAnimal.animalExhibit = exhibit;
					if (addAnimalSelectExhibitControl.selectedControl != null)
					{
						addAnimalSelectExhibitControl.selectedControl.BackColor = Color.DarkGray;
					}
					addAnimalSelectExhibitControl.RememberSelectedControl(this);
					addAnimalSelectExhibitControl.selectedControl.BackColor = Color.LimeGreen;
				}
				else if (!addAnimalSelectExhibitControl.addAnimalBasicInfoControl.CheckIfPreyPredatoryCheckBoxesAreChecked())
				{
					addAnimalSelectExhibitControl.addAnimalBasicInfoControl.SwitchToFirstPage();
					MessageBox.Show("You haven't selected wether or not the animal is predatory or prey!");
					return;
				}
			}
		}
	}
}
