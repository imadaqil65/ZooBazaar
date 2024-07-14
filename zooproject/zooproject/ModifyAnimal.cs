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
using zooproject.Domain.Domain.Enums;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;

namespace zooproject
{
    public partial class ModifyAnimal : Form
    {
        Animal selectedAnimal;
        Animals AnimalPage;
        AnimalManager animalManager;
        AnimalControl animalControl;
        public ModifyAnimal(Animals animalsPage, Animal animal, AnimalControl animalcontrol)
        {

            InitializeComponent();
            InstanciateObjects(animalsPage, animal);
            HidePartOfUI();
            FillingComboBoxes();
            FillAnimalDetails();
            animalControl = animalcontrol;
        }
        private void InstanciateObjects(Animals animalsPage, Animal animal)
        {
            AnimalPage = animalsPage;
            selectedAnimal = animal;
            animalManager = new AnimalManager(new AnimalDB());
        }
        private void FillingComboBoxes()
        {
            comboBox_EditAnimal_EnviromentType.DataSource = Enum.GetValues(typeof(EnviromentType));
            comboBox_EditAnimal_EditSpecies.DataSource = Enum.GetValues(typeof(AnimalSpecies));
            comboBox_EditAnimal_Gender.DataSource = Enum.GetValues(typeof(Gender));
        }

        private void FillAnimalDetails()
        {
            try
            {
                textBox_EditAnimal_Name.Text = selectedAnimal.Name;
                comboBox_EditAnimal_EditSpecies.SelectedItem = selectedAnimal.Species;
                comboBox_EditAnimal_Gender.SelectedItem = selectedAnimal.AnimalGender;
                if (selectedAnimal.Origin == "Zoo Bazaar")
                {
                    chboxBornEdit.Checked = true;
                    chboxAdoptedEdit.Checked = false;
                    chboxWildEdit.Checked = false;
                }
                else if (selectedAnimal.Origin == "The Wild")
                {
                    chboxWildEdit.Checked = true;
                    chboxAdoptedEdit.Checked = false;
                    chboxBornEdit.Checked = false;
                }
                else
                {
                    chboxAdoptedEdit.Checked = true;
                    chboxWildEdit.Checked = false;
                    chboxBornEdit.Checked = false;
                }
                dateTimePicker_EditAnimal_Birthday.Value = selectedAnimal.DateOfBirth;
                richTextBox_EditAnimal_Notes.Text = selectedAnimal.Notes;
                richTextBox_EditAnimal_Diet.Text = selectedAnimal.Diet;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }

        private void ModifyAnimal_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnimalPage.Show();
        }

        private void comboBox_EditAnimal_EditSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox_EditAnimal_Father.Items.Clear();
                comboBox_EditAnimal_Father.ResetText();
                comboBox_EditAnimal_Mother.Items.Clear();
                comboBox_EditAnimal_Mother.ResetText();
                List<Animal> animals = animalManager.GetAnimals();
                foreach (Animal animal in animals)
                {
                    if (animal.Species == (AnimalSpecies)comboBox_EditAnimal_EditSpecies.SelectedItem)
                    {
                        if (animal.AnimalGender == Gender.Male) { comboBox_EditAnimal_Father.Items.Add(animal); comboBox_EditAnimal_Father.SelectedIndex = 0; }
                        if (animal.AnimalGender == Gender.Female) { comboBox_EditAnimal_Mother.Items.Add(animal); comboBox_EditAnimal_Mother.SelectedIndex = 0; }
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }
        private void HidePartOfUI()
        {
            label24.Visible = false;
            label23.Visible = false;
            comboBox_EditAnimal_Father.Visible = false;
            comboBox_EditAnimal_Mother.Visible = false;
        }
            private void chboxBornEdit_CheckedChanged(object sender, EventArgs e)
        {
            int BornInZoo = Counter.GetEditBornInZooCounter();
            if (BornInZoo == 0)
            {
                label24.Visible = true;
                label23.Visible = true;
                comboBox_EditAnimal_Father.Visible = true;
                comboBox_EditAnimal_Mother.Visible = true;
            }
            if (BornInZoo == 1)
            {
                label24.Visible = false;
                label23.Visible = false;
                comboBox_EditAnimal_Father.Visible = false;
                comboBox_EditAnimal_Mother.Visible = false;
            }
        }
        private void ModifyAnimal_FormClosing(object sender, FormClosingEventArgs e)
        {
            animalControl.modifyAnimal = null;
            animalControl.BackColor = Color.DarkGray;
            Counter.UpdateMoveModifyAnimalFormCounter();
        }

        private void btnEditAnimal_Click_1(object sender, EventArgs e)
        {
            try
            {
                selectedAnimal.Name = textBox_EditAnimal_Name.Text;
                selectedAnimal.Species = (AnimalSpecies)comboBox_EditAnimal_EditSpecies.SelectedItem;
                selectedAnimal.AnimalGender = (Gender)comboBox_EditAnimal_Gender.SelectedItem;
                selectedAnimal.DateOfBirth = dateTimePicker_EditAnimal_Birthday.Value;

                if (chboxBornEdit.Checked == true)
                {
                    Animal father = (Animal)comboBox_EditAnimal_Father.SelectedItem;
                    Animal mother = (Animal)comboBox_EditAnimal_Mother.SelectedItem;
                    selectedAnimal.Relations = ("Father: " + father.Name + " Mother: " + mother.Name);
                    selectedAnimal.Origin = "Zoo Bazaar";
                    selectedAnimal.EnterDate = selectedAnimal.DateOfBirth;
                }
                if (chboxAdoptedEdit.Checked == true)
                {
                    ZooPartner zoo = (ZooPartner)comboBox_EditAnimal_SelectZoo.SelectedItem;
                    selectedAnimal.Origin = zoo.Name;
                    selectedAnimal.EnterDate = dtp_Edit_MoveInDate.Value.Date;
                }
                if (chboxWildEdit.Checked == true)
                {
                    selectedAnimal.Origin = "The Wild";
                }
                selectedAnimal.Notes = richTextBox_EditAnimal_Notes.Text;
                selectedAnimal.Diet = richTextBox_EditAnimal_Diet.Text;
                animalManager.UpdateAnimal(selectedAnimal);
                MessageBox.Show("Animal Succesfully Updated");
                AnimalPage.UpdateAnimalControlAll();
                this.Close();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }
    }
}
