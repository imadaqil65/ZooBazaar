using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.Zoo;
using zooproject.Logic.Services.Zoo;
using zooproject.Infrastructure.Databases.ZooPartners;
using zooproject.Infrastructure.Databases.Animals;
using Domain.Domain.Enums;

namespace zooproject.User_Controls
{
    public partial class AddAnimalBasicInfoControl : UserControl
    {
        AddAnimal addAnimal;
        ZooPartnerManager zooPartnerManager;
        AddAnimalSelectExhibitControl addAnimalSelectExhibitControl;
        public AddAnimalBasicInfoControl(AddAnimal addanimal, AddAnimalSelectExhibitControl addanimalselectexhibitcontrol)
        {
            InitializeComponent();
            this.addAnimal = addanimal;
            zooPartnerManager = new ZooPartnerManager(new ZooPartnerDB());
            addAnimalSelectExhibitControl = addanimalselectexhibitcontrol;
            FillingComboBoxes();
            HidePartOfUI();
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
        public bool CheckIfPreyPredatoryCheckBoxesAreChecked()
        {
            if (checkBox_AddAnimal_Predatory.Checked == true || checkBox_AddAnimal_Prey.Checked == true) { return true; }
            else { return false; }
        }
        private void FillingComboBoxes()
        {
            comboBox_AddAnimal_SelectSpecies.DataSource = Enum.GetValues(typeof(AnimalSpecies));
            comboBox_AddAnimal_EnviromentType.DataSource = Enum.GetValues(typeof(EnviromentType));
            comboBox_AddAnimal_Gender.DataSource = Enum.GetValues(typeof(Gender));
            comboBox_AddAnimal_SelectZoo.Items.Clear();
            comboBox_AddAnimal_PreferedSlot.DataSource = Enum.GetValues(typeof(FeedingTimeSlot));
            foreach (ZooPartner zooPartner in zooPartnerManager.GetAllZooPartners())
            {
                comboBox_AddAnimal_SelectZoo.Items.Add(zooPartner);
            }
        }
        private void checkBox_AddAnimal_Predatory_Click(object sender, EventArgs e)
        {
            if (checkBox_AddAnimal_Prey.CheckState == CheckState.Checked) { checkBox_AddAnimal_Predatory.Checked = true; checkBox_AddAnimal_Prey.Checked = false; return; }
        }
        private void checkBox_AddAnimal_Prey_Click(object sender, EventArgs e)
        {
            if (checkBox_AddAnimal_Predatory.CheckState == CheckState.Checked) { checkBox_AddAnimal_Prey.Checked = true; checkBox_AddAnimal_Predatory.Checked = false; }
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

        private void comboBox_AddAnimal_SelectSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnimalManager animalManager = new AnimalManager(new AnimalDB());
            comboBox_AddAnimal_Father.Items.Clear();
            comboBox_AddAnimal_Father.ResetText();
            comboBox_AddAnimal_Mother.Items.Clear();
            comboBox_AddAnimal_Mother.ResetText();
            List<Animal> animals = animalManager.GetAnimals();
            foreach (Animal animal in animals)
            {
                if (animal.Species == (AnimalSpecies)comboBox_AddAnimal_SelectSpecies.SelectedItem)
                {
                    if (animal.AnimalGender == Gender.Male) { comboBox_AddAnimal_Father.Items.Add(animal); comboBox_AddAnimal_Father.SelectedIndex = 0; }
                    if (animal.AnimalGender == Gender.Female) { comboBox_AddAnimal_Mother.Items.Add(animal); comboBox_AddAnimal_Mother.SelectedIndex = 0; }
                }
            }
        }

        private void checkBox_AddAnimal_BornZoo_CheckedChanged(object sender, EventArgs e)
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

        private void checkBox_AddAnimal_Predatory_CheckedChanged(object sender, EventArgs e)
        {
            if (addAnimal.addAnimalSelectExhibitControl != null)
            {
                addAnimal.addAnimalSelectExhibitControl.FillExhibitBox();
            }
        }

        private void checkBox_AddAnimal_Prey_CheckedChanged(object sender, EventArgs e)
        {
            if (addAnimal.addAnimalSelectExhibitControl != null)
            {
                addAnimal.addAnimalSelectExhibitControl.FillExhibitBox();
            }
        }

        private void comboBox_AddAnimal_EnviromentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addAnimal.addAnimalSelectExhibitControl != null)
            {
                addAnimal.addAnimalSelectExhibitControl.FillExhibitBox();
            }
        }
        public void SwitchToFirstPage()
        {
            addAnimal.SwitchToFirstPage();
        }

        private void DemoButton_Click(object sender, EventArgs e)
        {
            textBox_AddAnimal_Name.Text = "Bob";
            richTextBox_AddAnimal_Diet.Text = "Meat";
            richTextBox_AddAnimals_Notes.Text = "Needs Medication";
            checkBox_AddAnimal_Predatory.Checked = true;
            checkBox_AddAnimal_BornOutsideZoo.Checked = true;
            checkBox_AddAnimal_WildBorn.Checked = true;
            textBox_AddAnimal_Period.Text = 3.ToString();
            comboBox_AddAnimal_PreferedSlot.SelectedIndex = 2;
        }
    }
}
