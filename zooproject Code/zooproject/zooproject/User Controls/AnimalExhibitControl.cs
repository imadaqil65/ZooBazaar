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
        AnimalManager animalManager;


        public AnimalExhibitControl(Exhibit eXhibit, Animals animals)
        {
            InitializeComponent();
            animalManager = new AnimalManager(new AnimalDB());
            exhibit = eXhibit;
            aNimals = animals;
            lblName.Text = exhibit.Name;
            lblEnvironment.Text = exhibit.ExhibitType.ToString();
        }
        public AnimalExhibitControl(Exhibit exhibit, MoveAnimal animals)
        {
            InitializeComponent();
            this.mranimals = animals;
            this.exhibit = exhibit;

            lblName.Text = exhibit.Name;
            lblEnvironment.Text = exhibit.ExhibitType.ToString();
            
        }
        public AnimalExhibitControl(Exhibit exhibit, Exhibits exhibits)
        {
            InitializeComponent();
            this.ExHibits = exhibits;
            this.exhibit = exhibit;

            lblName.Text = exhibit.Name;
            lblEnvironment.Text = exhibit.ExhibitType.ToString();

        }
        public AnimalExhibitControl(Exhibit exhibit, EditExhibit exhibits)
        {
            InitializeComponent();
            this.editExhibit = exhibits;
            this.exhibit = exhibit;

            lblName.Text = exhibit.Name;
            lblEnvironment.Text = exhibit.ExhibitType.ToString();

        }
        public AnimalExhibitControl(Exhibit eXhibit, AddAnimal addanimal)
        {
            InitializeComponent();
            animalManager = new AnimalManager(new AnimalDB());
            this.exhibit = eXhibit;
            this.addAnimal = addanimal;

            lblName.Text = exhibit.Name;
            lblEnvironment.Text = exhibit.ExhibitType.ToString();
        }

        public AnimalExhibitControl(Exhibit eXhibit, AddFeedingTask feedingSchedule)
        {
            InitializeComponent();
            animalManager = new AnimalManager(new AnimalDB());
            exhibit = eXhibit;
            this.feedingSchedule = feedingSchedule;
            lblName.Text = exhibit.Name;
            lblEnvironment.Text = exhibit.ExhibitType.ToString();
        }
        private void SelectClick(object sender, EventArgs e)
        {
            if (mranimals != null)
            {
                mranimals.GetExhibit(exhibit);
            }
            if (ExHibits != null)
            {

            }
            if (aNimals != null)
            {
                aNimals.animalExhibit = exhibit;
            }
            if (addAnimal!= null)
            {
                List<Animal> animalslist = animalManager.ReadByExhibit(exhibit);
                addAnimal.AddAnimalsFromExhibit(animalslist);
                addAnimal.animalExhibit = exhibit;
                
            }
            feedingSchedule.selectedExhibit = exhibit;
            MessageBox.Show("Exhibit Selected");
        }
    }
}