using Domain.Domain.Enums;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.Exceptions;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Infrastructure.Databases.ZooPartners;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;

namespace zooproject
{
    public partial class AddAnimal : Form
    {
        Animals AnimalPage;
        AnimalManager animalmanager;
        ExhibitManager exhibitManager;
        ZooPartnerManager zooPartnerManager;

        public Exhibit? animalExhibit = null;

        public UserControl? currentControl;
		public AnimalExhibitControl? selectedControl;
        public AddAnimalBasicInfoControl addAnimalBasicInfoControl;
        public AddAnimalSelectExhibitControl addAnimalSelectExhibitControl;

		public AddAnimal(Animals animalspage)
        {
            InitializeComponent();
            AnimalPage = animalspage;
            animalmanager = new AnimalManager(new AnimalDB());
            exhibitManager = new ExhibitManager(new ExhibitDB());
            zooPartnerManager = new ZooPartnerManager(new ZooPartnerDB());
			addAnimalBasicInfoControl = new AddAnimalBasicInfoControl(this, addAnimalSelectExhibitControl);
			addAnimalSelectExhibitControl = new AddAnimalSelectExhibitControl(this, addAnimalBasicInfoControl);
			flowLayoutPanel2.Controls.Add(addAnimalSelectExhibitControl);
            flowLayoutPanel1.Controls.Add(addAnimalBasicInfoControl);
            flowLayoutPanel2.Visible = false;
			currentControl = addAnimalBasicInfoControl;
            flowLayoutPanel1.Controls.Add(addAnimalBasicInfoControl);
        }
       
        private void AddAnimal_FormClosed(object sender, FormClosedEventArgs e)
        {
			Counter.ResetAddAnimalCounter();
		}
		private void button_Next_Click(object sender, EventArgs e)
		{
			if (currentControl == null || currentControl.GetType() == typeof(AddAnimalSelectExhibitControl)) { MessageBox.Show("Already on the last page!"); return; }
			else if (currentControl.GetType() == typeof(AddAnimalBasicInfoControl))
			{
				if(addAnimalSelectExhibitControl != null)
				{
                    addAnimalSelectExhibitControl.FillExhibitBox();
                }
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel2.Visible = true;
                currentControl = addAnimalSelectExhibitControl;
			}
		}
		private void button_Previous_Click(object sender, EventArgs e)
		{
            if(currentControl == null || currentControl.GetType() == typeof(AddAnimalBasicInfoControl)) { MessageBox.Show("Already on the first page!"); return; }
            else if(currentControl.GetType() == typeof(AddAnimalSelectExhibitControl))
            {
                flowLayoutPanel1.Visible = true;
                flowLayoutPanel2.Visible = false;
                currentControl = addAnimalBasicInfoControl;
            }
		}
        public void SwitchToFirstPage()
        {
			flowLayoutPanel1.Visible = true;
			flowLayoutPanel2.Visible = false;
            currentControl = addAnimalBasicInfoControl;
		}

		private void button_AddAnimal_Click(object sender, EventArgs e)
		{
			try
			{
				if (addAnimalBasicInfoControl.checkBox_AddAnimal_Predatory.Checked == false && addAnimalBasicInfoControl.checkBox_AddAnimal_Prey.Checked == false) { MessageBox.Show("Animal must be either Predatory or Prey"); return; }
				if (addAnimalBasicInfoControl.checkBox_AddAnimal_Predatory.Checked == true && addAnimalBasicInfoControl.checkBox_AddAnimal_Prey.Checked == true) { MessageBox.Show("Animal must be either Predatory or Prey, not both"); return; }
				if (addAnimalBasicInfoControl.checkBox_AddAnimal_AdoptedZoo.Checked == true && addAnimalBasicInfoControl.checkBox_AddAnimal_WildBorn.Checked == true) { MessageBox.Show("Animal can't be wild born and addopted from anoher zoo"); return; }
				//^checking if the user hasn't checked none or multiple boxes

				string name = addAnimalBasicInfoControl.textBox_AddAnimal_Name.Text.ToString().Trim();
				AnimalSpecies species = (AnimalSpecies)addAnimalBasicInfoControl.comboBox_AddAnimal_SelectSpecies.SelectedItem;
				DateTime dateofbirth = addAnimalBasicInfoControl.dtpAnimalBirthday.Value.Date;
				DateTime enterdate = DateTime.Now.Date;

				Gender gender = (Gender)addAnimalBasicInfoControl.comboBox_AddAnimal_Gender.SelectedItem;

				bool isPredator = false;
				bool isPrey = false;
				if (addAnimalBasicInfoControl.checkBox_AddAnimal_Predatory.Checked) { isPredator = true; }
				else { isPredator = false; }
				if (addAnimalBasicInfoControl.checkBox_AddAnimal_Prey.Checked) { isPrey = true; }
				else { isPrey = false; }

				string diet = addAnimalBasicInfoControl.richTextBox_AddAnimal_Diet.Text.ToString().Trim();
				string notes = addAnimalBasicInfoControl.richTextBox_AddAnimals_Notes.Text.ToString().Trim();
				string origin = "";
				string relations = "";

				if (addAnimalBasicInfoControl.checkBox_AddAnimal_BornZoo.Checked == true)
				{
					Animal father = (Animal)addAnimalBasicInfoControl.comboBox_AddAnimal_Father.SelectedItem;
					Animal mother = (Animal)addAnimalBasicInfoControl.comboBox_AddAnimal_Mother.SelectedItem;
					relations = ("Father: " + father.Name + " Mother: " + mother.Name);
					origin = "Zoo Bazaar";
					enterdate = dateofbirth;
				}
				if (addAnimalBasicInfoControl.checkBox_AddAnimal_AdoptedZoo.Checked == true)
				{
					ZooPartner zoo = (ZooPartner)addAnimalBasicInfoControl.comboBox_AddAnimal_SelectZoo.SelectedItem;
					origin = zoo.Name;
					enterdate = addAnimalBasicInfoControl.dtpAnimalMoveIn.Value.Date;
				}
				if (addAnimalBasicInfoControl.checkBox_AddAnimal_WildBorn.Checked == true)
				{
					origin = "The Wild";
				}
				if (addAnimalBasicInfoControl.checkBox_AddAnimal_KnownParents.Checked == true)
				{
					Animal father = (Animal)addAnimalBasicInfoControl.comboBox_AddAnimal_KnownFather.SelectedItem;
					Animal mother = (Animal)addAnimalBasicInfoControl.comboBox_AddAnimal_KnownMother.SelectedItem;
					relations = ("Father: " + father.Name + " Mother: " + mother.Name);
				}
				if (animalExhibit == null) { MessageBox.Show("No Exhibit Was Selected"); return; }
				int exhibitID = animalExhibit.Id;
				EnviromentType enviromentType = (EnviromentType)addAnimalBasicInfoControl.comboBox_AddAnimal_EnviromentType.SelectedItem;
				int feedingPeriod = Convert.ToInt32(addAnimalBasicInfoControl.textBox_AddAnimal_Period.Text);
				FeedingTimeSlot preferedSlot = (FeedingTimeSlot)addAnimalBasicInfoControl.comboBox_AddAnimal_PreferedSlot.SelectedItem;
				animalmanager.CreateAnimal(name, species, enterdate, origin, gender, dateofbirth, diet, notes, relations, exhibitID, isPredator, isPrey, enviromentType,feedingPeriod,preferedSlot);
                AnimalPage.UpdateAnimalControlAll();
                MessageBox.Show("Animal Succesfully Added");
			}
			catch (DomainException Ex)
			{
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
			catch (Exception Ex)
			{
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }

		}
	}
}