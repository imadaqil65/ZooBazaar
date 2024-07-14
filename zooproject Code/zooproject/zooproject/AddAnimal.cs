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

        public AddAnimal(Animals animalspage)
        {
            InitializeComponent();
            AnimalPage = animalspage;
            animalmanager = new AnimalManager(new AnimalDB());
            exhibitManager = new ExhibitManager(new ExhibitDB());
            zooPartnerManager = new ZooPartnerManager(new DBZooPartner());
            FillingComboBoxes();
            HidePartOfUI();
        }
        private void FillingComboBoxes()
        {
            comboBox_AddAnimal_SelectSpecies.DataSource = Enum.GetValues(typeof(AnimalSpecies));
            comboBox_AddAnimal_EnviromentType.DataSource = Enum.GetValues(typeof(EnviromentType));
            comboBox_AddAnimal_Gender.DataSource = Enum.GetValues(typeof(Gender));
            comboBox_AddAnimal_SelectZoo.Items.Clear();
            foreach (ZooPartner zooPartner in zooPartnerManager.GetAllZooPartners())
            {
                comboBox_AddAnimal_SelectZoo.Items.Add(zooPartner);
            }
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
        private void AddAnimal_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnimalPage.Show();
        }

        private void HidePartOfUI()
        {
            label_Animals_AddAnimal_SelectFather.Visible = false;
            label_Animals_AddAnimal_SelectMother.Visible = false;
            comboBox_AddAnimal_Father.Visible = false;
            comboBox_AddAnimal_Mother.Visible = false;

            label_AddAnimal_KnownFather.Visible = false;
            label_AddAnimal_KnownMother.Visible = false;
            comboBox_AddAnimal_KnownFather.Visible = false;
            comboBox_AddAnimal_KnownMother.Visible = false;

            checkBox_AddAnimal_AdoptedZoo.Visible = false;
            checkBox_AddAnimal_WildBorn.Visible = false;

            label_AddAnimal_SelectZoo.Visible = false;
            label_MoveInDate.Visible = false;
            comboBox_AddAnimal_SelectZoo.Visible = false;
            dtpAnimalMoveIn.Visible = false;

            checkBox_AddAnimal_KnownParents.Visible = false;
        }

        private void checkBox_AddAnimal_Predatory_Click(object sender, EventArgs e)
        {
            if (checkBox_AddAnimal_Prey.CheckState == CheckState.Checked) { checkBox_AddAnimal_Predatory.Checked = false; MessageBox.Show("Animal Can't Be Prey And Predetory At The Same Time"); return; }
        }
        private void checkBox_AddAnimal_Prey_Click(object sender, EventArgs e)
        {
            if (checkBox_AddAnimal_Predatory.CheckState == CheckState.Checked) { checkBox_AddAnimal_Prey.Checked = false; MessageBox.Show("Animal Can't Be Prey And Predetory At The Same Time"); return; }
        }
        private void checkBox_AddAnimal_BornZoo_Click(object sender, EventArgs e)
        {
            if (checkBox_AddAnimal_BornOutsideZoo.CheckState == CheckState.Checked) { checkBox_AddAnimal_BornZoo.Checked = false; MessageBox.Show("Animal Can't Be Born Inside And Outisde The Zoo At The Same Time"); return; }
        }
        private void checkBox_AddAnimal_BornOutsideZoo_Click(object sender, EventArgs e)
        {
            if (checkBox_AddAnimal_BornZoo.CheckState == CheckState.Checked) { checkBox_AddAnimal_BornOutsideZoo.Checked = false; MessageBox.Show("Animal Can't Be Born Inside And Outisde The Zoo At The Same Time"); return; }
        }
        private void checkBox_AddAnimal_WildBorn_Click(object sender, EventArgs e)
        {
            if (checkBox_AddAnimal_KnownParents.CheckState == CheckState.Checked) { checkBox_AddAnimal_WildBorn.Checked = false; MessageBox.Show("Animal Can't Be Wild Born And Have Known Parents At The Same Time"); return; }
        }
        private void checkBox_AddAnimal_KnownParents_Click(object sender, EventArgs e)
        {
            if (checkBox_AddAnimal_WildBorn.CheckState == CheckState.Checked) { checkBox_AddAnimal_KnownParents.Checked = false; MessageBox.Show("Animal Can't Be Wild Born And Have Known Parents At The Same Time"); return; }
        }
        private void button_AddAnimal_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_AddAnimal_Predatory.Checked == false && checkBox_AddAnimal_Prey.Checked == false) { MessageBox.Show("Animal must be either Predatory or Prey"); return; }
                if (checkBox_AddAnimal_Predatory.Checked == true && checkBox_AddAnimal_Prey.Checked == true) { MessageBox.Show("Animal must be either Predatory or Prey, not both"); return; }
                if (checkBox_AddAnimal_AdoptedZoo.Checked == true && checkBox_AddAnimal_WildBorn.Checked == true) { MessageBox.Show("Animal can't be wild born and addopted from anoher zoo"); return; }
                //^checking if the user hasn't checked none or multiple boxes

                string name = textBox_AddAnimal_Name.Text.ToString().Trim();
                AnimalSpecies species = (AnimalSpecies)comboBox_AddAnimal_SelectSpecies.SelectedItem;
                DateTime dateofbirth = dtpAnimalBirthday.Value.Date;
                DateTime enterdate = DateTime.Now.Date;

                Gender gender = (Gender)comboBox_AddAnimal_Gender.SelectedItem;

                bool isPredator = false;
                bool isPrey = false;
                if (checkBox_AddAnimal_Predatory.Checked) { isPredator = true; }
                else { isPredator = false; }
                if (checkBox_AddAnimal_Prey.Checked) { isPrey = true; }
                else { isPrey = false; }

                string diet = richTextBox_AddAnimal_Diet.Text.ToString().Trim();
                string notes = richTextBox_AddAnimals_Notes.Text.ToString().Trim();
                string origin = "";
                string relations = "";

                if (checkBox_AddAnimal_BornZoo.Checked == true)
                {
                    Animal father = (Animal)comboBox_AddAnimal_Father.SelectedItem;
                    Animal mother = (Animal)comboBox_AddAnimal_Mother.SelectedItem;
                    relations = ("Father: " + father.Name + " Mother: " + mother.Name);
                    origin = "Zoo Bazaar";
                    enterdate = dateofbirth;
                }
                if (checkBox_AddAnimal_AdoptedZoo.Checked == true)
                {
                    ZooPartner zoo = (ZooPartner)comboBox_AddAnimal_SelectZoo.SelectedItem;
                    origin = zoo.Name;
                    enterdate = dtpAnimalMoveIn.Value.Date;
                }
                if (checkBox_AddAnimal_WildBorn.Checked == true)
                {
                    origin = "The Wild";
                }
                if (checkBox_AddAnimal_KnownParents.Checked == true)
                {
                    Animal father = (Animal)comboBox_AddAnimal_KnownFather.SelectedItem;
                    Animal mother = (Animal)comboBox_AddAnimal_KnownMother.SelectedItem;
                    relations = ("Father: " + father.Name + " Mother: " + mother.Name);
                }
                if (animalExhibit == null) { MessageBox.Show("No Exhibit Was Selected"); return; }
                int exhibitID = animalExhibit.Id;
                animalmanager.CreateAnimal(name, species, enterdate, origin, gender, dateofbirth, diet, notes, relations, exhibitID, isPredator, isPrey);
                MessageBox.Show("Animal Succesfully Added");
            }
            catch (DomainException Ex)
            {
                MessageBox.Show(Ex.Message);
                Console.WriteLine(Ex);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void comboBox_AddAnimal_SelectSpecies_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox_AddAnimal_Father.Items.Clear();
            comboBox_AddAnimal_Father.ResetText();
            comboBox_AddAnimal_Mother.Items.Clear();
            comboBox_AddAnimal_Mother.ResetText();
            List<Animal> animals = animalmanager.GetAnimals();
            foreach (Animal animal in animals)
            {
                if (animal.Species == (AnimalSpecies)comboBox_AddAnimal_SelectSpecies.SelectedItem)
                {
                    if (animal.AnimalGender == Gender.Male) { comboBox_AddAnimal_Father.Items.Add(animal); comboBox_AddAnimal_Father.SelectedIndex = 0; }
                    if (animal.AnimalGender == Gender.Female) { comboBox_AddAnimal_Mother.Items.Add(animal); comboBox_AddAnimal_Mother.SelectedIndex = 0; }
                }
            }
        }

        private void checkBox_AddAnimal_BornZoo_CheckedChanged_1(object sender, EventArgs e)
        {
            int BornInZoo = Counter.GetBornInZooCounter();
            if (BornInZoo == 0)
            {
                label_Animals_AddAnimal_SelectFather.Visible = true;
                label_Animals_AddAnimal_SelectMother.Visible = true;
                comboBox_AddAnimal_Father.Visible = true;
                comboBox_AddAnimal_Mother.Visible = true;
            }
            if (BornInZoo == 1)
            {
                label_Animals_AddAnimal_SelectFather.Visible = false;
                label_Animals_AddAnimal_SelectMother.Visible = false;
                comboBox_AddAnimal_Father.Visible = false;
                comboBox_AddAnimal_Mother.Visible = false;
            }
        }

        private void checkBox_AddAnimal_BornOutsideZoo_CheckedChanged(object sender, EventArgs e)
        {
            int BornOutSideZoo = Counter.GetBornOutsideZooCounter();
            if (BornOutSideZoo == 0)
            {
                checkBox_AddAnimal_AdoptedZoo.Visible = true;
                checkBox_AddAnimal_WildBorn.Visible = true;

                if (checkBox_AddAnimal_AdoptedZoo.Checked == true)
                {
                    label_AddAnimal_SelectZoo.Visible = true;
                    comboBox_AddAnimal_SelectZoo.Visible = true;
                }
                label_MoveInDate.Visible = true;
                dtpAnimalMoveIn.Visible = true;

                checkBox_AddAnimal_KnownParents.Visible = true;
                if (checkBox_AddAnimal_KnownParents.Checked == true)
                {
                    label_AddAnimal_KnownFather.Visible = true;
                    label_AddAnimal_KnownMother.Visible = true;
                    comboBox_AddAnimal_KnownFather.Visible = true;
                    comboBox_AddAnimal_KnownMother.Visible = true;
                }
            }
            else if (BornOutSideZoo == 1)
            {
                checkBox_AddAnimal_AdoptedZoo.Visible = false;
                checkBox_AddAnimal_WildBorn.Visible = false;

                label_AddAnimal_SelectZoo.Visible = false;
                label_MoveInDate.Visible = false;
                comboBox_AddAnimal_SelectZoo.Visible = false;
                dtpAnimalMoveIn.Visible = false;

                checkBox_AddAnimal_KnownParents.Visible = false;

                label_AddAnimal_KnownFather.Visible = false;
                label_AddAnimal_KnownMother.Visible = false;
                comboBox_AddAnimal_KnownFather.Visible = false;
                comboBox_AddAnimal_KnownMother.Visible = false;
            }
        }

        private void checkBox_AddAnimal_AdoptedZoo_CheckedChanged(object sender, EventArgs e)
        {
            int AdoptedCounter = Counter.GetAdoptedCounter();

            if (AdoptedCounter == 0)
            {
                label_AddAnimal_SelectZoo.Visible = true;
                comboBox_AddAnimal_SelectZoo.Visible = true;
            }
            else if (AdoptedCounter == 1)
            {
                label_AddAnimal_SelectZoo.Visible = false;
                comboBox_AddAnimal_SelectZoo.Visible = false;
            }
        }

        private void checkBox_AddAnimal_KnownParents_CheckedChanged(object sender, EventArgs e)
        {
            int KnownParents = Counter.GetKnownParentsCounter();
            if (KnownParents == 0)
            {
                label_AddAnimal_KnownFather.Visible = true;
                label_AddAnimal_KnownMother.Visible = true;
                comboBox_AddAnimal_KnownFather.Visible = true;
                comboBox_AddAnimal_KnownMother.Visible = true;
            }
            else if (KnownParents == 1)
            {
                label_AddAnimal_KnownFather.Visible = false;
                label_AddAnimal_KnownMother.Visible = false;
                comboBox_AddAnimal_KnownFather.Visible = false;
                comboBox_AddAnimal_KnownMother.Visible = false;
            }
        }
        private void FillExhibitBox()
        {
            flpAnimalExibits.Controls.Clear();
            foreach (var result in exhibitManager.ReadAllExhibits())
            {
                AnimalExhibitControl exhibitControl = new AnimalExhibitControl(result, this);
                flpAnimalExibits.Controls.Add(exhibitControl);
            }
        }
        private void btnReloadExhibits_Click(object sender, EventArgs e)
        {
            FillExhibitBox();
        }
    }
}