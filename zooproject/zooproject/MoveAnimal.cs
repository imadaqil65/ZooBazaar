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
using zooproject.Events;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Infrastructure.Databases.Zones;
using zooproject.Infrastructure.Databases.ZooPartners;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;
using static zooproject.Events.ExhibitFilterEvent;

namespace zooproject
{
    public partial class MoveAnimal : Form
    {
        Animals animalPage;
        Animal animal;
        Exhibit currentExhibit;
		ExhibitFilterEvent exhibitFilterEvent;
        public AnimalExhibitControl? selectedControl;
		ExhibitManager exhibitManager;
        AnimalManager animalManager;
        AnimalManager removedAnimalManager;
        private Exhibit animalExhibit;
        internal Animal animalToBeRemoved;
        ZooPartnerManager zooPartnerManager;
        ZoneManager zoneManager;
        AnimalControl animalControl;

        public MoveAnimal(Animals AnimalsPage, Animal Animal, AnimalControl animalcontrol)
        {
            InitializeComponent();
            animalPage = AnimalsPage;
            animal = Animal;
            animalToBeRemoved = Animal;
            exhibitManager = new ExhibitManager(new ExhibitDB());
            animalManager = new AnimalManager(new AnimalDB());
            removedAnimalManager = new AnimalManager(new RemovedAnimalDB());
            zooPartnerManager = new ZooPartnerManager(new ZooPartnerDB());
            zoneManager = new ZoneManager(new ZoneDB());
            animalControl = animalcontrol;
            SetComboBoxes();
            UpdateCurrentExhibit();
            
        }
        private void SetComboBoxes()
        {
            cmBoxMoveAnimalZoo.Items.Clear();
            foreach (ZooPartner zooPartner in zooPartnerManager.GetAllZooPartners())
            {
                cmBoxMoveAnimalZoo.Items.Add(zooPartner);
            }
            if (cmBoxMoveAnimalZoo.Items.Count > 0)
            {
                cmBoxMoveAnimalZoo.SelectedIndex = 0;
            }
            comboBox_MoveAnimal_SelectExhibit.Items.Clear();
            foreach (Zone zone in zoneManager.GetAllZones())
            {
                comboBox_MoveAnimal_SelectExhibit.Items.Add(zone);
            }
            if (comboBox_MoveAnimal_SelectExhibit.Items.Count > 0)
            {
                comboBox_MoveAnimal_SelectExhibit.SelectedIndex = 0;
            }
        }
        private void UpdateCurrentExhibit()
        {
            try
            {
                flowLayoutPanel2.Controls.Clear();
                currentExhibit = animalManager.GetExhibit(animal.exhibitID);
                if (currentExhibit != null)
                {
                    CurrentExhibitControl currentExhibitControl = new CurrentExhibitControl(currentExhibit);
                    flowLayoutPanel2.Controls.Add(currentExhibitControl);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }

		private void MoveRemoveAnimal_FormClosed(object sender, FormClosedEventArgs e)
        {
            animalPage.Show();
        }
        public void GetExhibit(Exhibit exhibit)
        {
            try
            {
                animalExhibit = exhibit;
                List<Animal> animals = animalManager.ReadByExhibit(animalExhibit);
                flowLayoutPanel_AnimalsInExhibit.Controls.Clear();
                foreach (Animal animal in animals)
                {
                    AnimalDisplayControl animalControl = new AnimalDisplayControl(animal, this);
                    flowLayoutPanel_AnimalsInExhibit.Controls.Add(animalControl);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }
        private void btnMoveAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton_Internal.Checked)
                {
                    animalToBeRemoved.exhibitID = animalExhibit.Id;
                    animalManager.UpdateAnimal(animalToBeRemoved);
                    UpdateCurrentExhibit();

                }
                else if (radioButton_External.Checked)
                {
                    //External Move = Leaving Mode 0;
                    ZooPartner zooPartner = (ZooPartner)cmBoxMoveAnimalZoo.SelectedItem;
                    animalToBeRemoved.LeavingDate = dtpMoveAnimalMovingDate.Value.Date;
                    animalToBeRemoved.LeavingReason = rtxtBoxMoveAnimalMovingReason.Text + "\x0AMoved to: " + "\x0A" + zooPartner.Name.ToString();
                    animalManager.RemoveAnimal(animalToBeRemoved);
                    removedAnimalManager.CreateRemovedAnimal(animalToBeRemoved, 0);
                    UpdateCurrentExhibit();
                }
                else if (radioButton_Deceased.Checked)
                {
                    //Deceased = Leaving Mode 1;
                    animalToBeRemoved.LeavingDate = dtpMoveAnimalMovingDate.Value.Date;
                    animalToBeRemoved.LeavingReason = rtxtBoxMoveAnimalMovingReason.Text;
                    animalManager.RemoveAnimal(animalToBeRemoved);
                    removedAnimalManager.CreateRemovedAnimal(animalToBeRemoved, 1);
                    UpdateCurrentExhibit();
                }
                MessageBox.Show("Animal Succesfully Moved");
                animalPage.UpdateAnimalControlAll();
                this.Close();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }
        public void RememberSelectedControl(AnimalExhibitControl animalexhibitcontrol)
        {
            selectedControl = animalexhibitcontrol;
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                flpMoveAnimalsExhibit.Controls.Clear();
                flowLayoutPanel_AnimalsInExhibit.Controls.Clear();
                selectedControl = null;
                foreach (var result in exhibitManager.ReadAllExhibits())
                {
                    if (result.ExhibitType == animal.AnimalEnviroment)
                    {
                        if (result.PredatorOrPrey == true && animal.IsPredator == true)
                        {
                            AnimalExhibitControl animalControl = new AnimalExhibitControl(result, this);
                            flpMoveAnimalsExhibit.Controls.Add(animalControl);
                        }
                        else if (result.PredatorOrPrey == false && animal.IsPrey == true)
                        {
                            AnimalExhibitControl animalControl = new AnimalExhibitControl(result, this);
                            flpMoveAnimalsExhibit.Controls.Add(animalControl);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }
        private void button_ApplyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                flpMoveAnimalsExhibit.Controls.Clear();
                flowLayoutPanel_AnimalsInExhibit.Controls.Clear();
                selectedControl = null;
                Zone zone = (Zone)comboBox_MoveAnimal_SelectExhibit.SelectedItem;
                foreach (var result in exhibitManager.ReadAllExhibits())
                {
                    if (zone.ZoneId == result.ZoneId)
                    {
                        if (result.ExhibitType == animal.AnimalEnviroment)
                        {
                            if (result.PredatorOrPrey == true && animal.IsPredator == true)
                            {
                                AnimalExhibitControl animalControl = new AnimalExhibitControl(result, this);
                                flpMoveAnimalsExhibit.Controls.Add(animalControl);
                            }
                            else if (result.PredatorOrPrey == false && animal.IsPrey == true)
                            {
                                AnimalExhibitControl animalControl = new AnimalExhibitControl(result, this);
                                flpMoveAnimalsExhibit.Controls.Add(animalControl);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                MessageBox.Show("Error Occured, \x0aThe Following Message Was Attatched: \x0a\x0a" + Ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton_External.Checked && Counter.GetExternalMoveCounter() == 0)
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("External Move selected, cannot select an exhibit!");
            }
            else if (radioButton_Deceased.Checked && Counter.GetExternalMoveCounter() == 0)
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("Animal is deceased selected, cannot select an exhibit!");
            }
            else if (!radioButton_Internal.Checked && !radioButton_External.Checked && !radioButton_Deceased.Checked && Counter.GetExternalMoveCounter() == 0)
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("None of the radiobuttons have been checked!");
            }
        }

        private void MoveAnimal_FormClosing(object sender, FormClosingEventArgs e)
        {
            animalControl.moveAnimal = null;
            animalControl.BackColor = Color.DarkGray;
            Counter.UpdateMoveModifyAnimalFormCounter();
        }
    }
}
