using zooproject.Domain.Domain.Zoo;
using zooproject.Domain.Domain.Exceptions;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Logic.Services.Zoo;
using zooproject.Domain.Domain.FilterObjects;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.User_Controls;
using zooproject.Events;
using static zooproject.Events.AnimalFilterEvent;
using Domain.Domain.Exceptions;

namespace zooproject
{
    public partial class AnimalFilters : Form
    {
        Animals animals;
        MoveAnimal moveAnimal;
        AnimalFilterEvent animalFilterEvent = new AnimalFilterEvent();

        public AnimalFilters(Animals aNimals)
        {
            InitializeComponent();
            SetComboBoxes();
            SetUpTables();
            animals = aNimals;
            animalFilterEvent.animalEvent += new AnimalFilterEventHandler(animals.UpdateAnimalControlFiltered);

        }
        private void SetComboBoxes()
        {
            try
            {
                comboBox_Species.DataSource = Enum.GetValues(typeof(AnimalSpecies));
                comboBox_EnviromentType.DataSource = Enum.GetValues(typeof(EnviromentType));
                ExhibitManager exhibitManager = new ExhibitManager(new ExhibitDB());
                foreach (Exhibit exhibit in exhibitManager.ReadAllExhibits())
                {
                    comboBox_Exhibit.Items.Add(exhibit);
                }
                comboBox_Exhibit.SelectedIndex = 0;
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + ex.Message);
            }
     
        }
        private void SetUpTables()
        {
            try
            {
                label4.Visible = false;
                label4.Text = "Selected";
                label5.Visible = false;
                label5.Text = "Selected";
                label6.Visible = false;
                label6.Text = "Selected";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + ex.Message);
            }
        }
		public List<AnimalControl> GetFilteredList()
        {
            List<AnimalControl> FilteredAnimals = new List<AnimalControl>();
            try
            {
                AnimalManager animalManager = new AnimalManager(new AnimalDB());
                int animalSpecies;
                int animalEnviroment;
                int exhibitID;
                bool predator = false;
                bool prey = false;
                if (checkBox_Species.Checked == false) { animalSpecies = -1; }
                else { animalSpecies = Convert.ToInt32((AnimalSpecies)comboBox_Species.SelectedItem); }
                if (checkBox_EnviromentType.Checked == false) { animalEnviroment = -1; }
                else { animalEnviroment = Convert.ToInt32((EnviromentType)comboBox_EnviromentType.SelectedItem); }
                if (checkBox_Exhibit.Checked == false) { exhibitID = -1; }
                else
                {
                    Exhibit exhibit = (Exhibit)comboBox_Exhibit.SelectedItem;
                    exhibitID = exhibit.Id;
                }
                if (checkBox_Predator.Checked == true) { predator = true; }
                if (checkBox_Prey.Checked == true) { prey = true; }
                List<Animal> animalList = animalManager.ReadAllAnimals();

                foreach (Animal animal in animalList.ToList())
                {
                    if (animalSpecies != -1)
                    {
                        if ((AnimalSpecies)animalSpecies != animal.Species)
                        {
                            animalList.Remove(animal);
                        }
                    }
                    if (animalEnviroment != -1)
                    {
                        if ((EnviromentType)animalEnviroment != animal.AnimalEnviroment)
                        {
                            animalList.Remove(animal);
                        }
                    }
                    if (exhibitID != -1)
                    {
                        if (exhibitID != animal.exhibitID)
                        {
                            animalList.Remove(animal);
                        }
                    }
                    if (predator == true || prey == true)
                    {
                        if (predator == true && predator != animal.IsPredator)
                        {
                            animalList.Remove(animal);
                        }
                        else if (prey == true && prey != animal.IsPrey)
                        {
                            animalList.Remove(animal);
                        }
                    }
                }
                foreach (Animal animal in animalList)
                {
                    AnimalControl animalControl = new AnimalControl(animal, animals);
                    FilteredAnimals.Add(animalControl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + ex.Message);
            }
            return FilteredAnimals;
        }
        private void button_ApplyFilter_Click(object sender, EventArgs e)
        {
			int animalSpecies;
			int animalEnviroment;
			int exhibitID;
			bool predator = false;
			bool prey = false;
			if (checkBox_Species.Checked == false) { animalSpecies = -1; }
			else { animalSpecies = Convert.ToInt32((AnimalSpecies)comboBox_Species.SelectedItem); }
			if (checkBox_EnviromentType.Checked == false) { animalEnviroment = -1; }
			else { animalEnviroment = Convert.ToInt32((EnviromentType)comboBox_EnviromentType.SelectedItem); }
			if (checkBox_Exhibit.Checked == false) { exhibitID = -1; }
			else
			{
				Exhibit exhibit = (Exhibit)comboBox_Exhibit.SelectedItem;
				exhibitID = exhibit.Id;
			}
			if (checkBox_Predator.Checked == true) { predator = true; }
			if (checkBox_Prey.Checked == true) { prey = true; }

            animalFilterEvent.SentFilteredAnimals(animalSpecies, animalEnviroment, exhibitID, predator, prey);
		}

		private void checkBox_Species_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBox_Species.Checked == true) { label4.Visible = true; }
            else { label4.Visible = false; }
		}
		private void checkBox_EnviromentType_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_EnviromentType.Checked == true) { label5.Visible = true; }
			else { label5.Visible = false; }
		}
		private void checkBox_Exhibit_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBox_Exhibit.Checked == true) { label6.Visible = true; }
            else { label6.Visible = false; }
		}

        private void AnimalFilters_FormClosing(object sender, FormClosingEventArgs e)
        {
            animals.animalFilters = null;
        }
    }
}