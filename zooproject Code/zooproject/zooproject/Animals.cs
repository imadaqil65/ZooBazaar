using zooproject.Domain.Domain.Zoo;
using zooproject.Domain.Domain.Enums;

using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;

using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Infrastructure.Databases.Zones;

using zooproject.User_Controls;

namespace zooproject
{
    public partial class Animals : Form
    {
        Exhibit selectedExhibit;
        Animal selectedAnimal;
        internal Zone selectedZone;
        internal Animal animalToBeRemoved;
        AnimalManager animalmanager;
        AnimalManager removedAnimalManager;
        ExhibitManager exhibitManager;
        EmployeeManager employeeManager;
        ZoneManager zoneManager;
        public Exhibit animalExhibit { get; set; }

        public Animals(EmployeeManager employeemanager)
        {
            InitializeComponent();
            employeeManager = employeemanager;
            InstantiateManagerClasses();
            FillingComboBoxes();
        }
        private void FillingComboBoxes()
        {
            comboBox_EditAnimal_SelectSpecies.DataSource = Enum.GetValues(typeof(AnimalSpecies));
        }
        private void InstantiateManagerClasses()
        {
            animalmanager = new AnimalManager(new AnimalDB()); //Is going to get moved to the LoginForm instead
            removedAnimalManager = new AnimalManager(new RemovedAnimalDB());
            exhibitManager = new ExhibitManager(new ExhibitDB());
            zoneManager = new ZoneManager(new ZoneDB());
        }
        //All Animal CRUD things are in the region, open it
        #region Animal Controls

        public void UpdateAnimalControlAll()
        {
            List<Animal> results = new List<Animal>();
            flpAnimals.Controls.Clear();
            foreach (var result in animalmanager.ReadAllAnimals())
            {
                AnimalControl animalControl = new AnimalControl(result, this);
                flpAnimals.Controls.Add(animalControl);
            }
        }
        private void UpdateAnimalControlSpecies()
        {
            flpAnimals.Controls.Clear();
            foreach (var result in animalmanager.ReadBySpecies((AnimalSpecies)comboBox_EditAnimal_SelectSpecies.SelectedItem))
            {
                AnimalControl animalControl = new AnimalControl(result, this);
                flpAnimals.Controls.Add(animalControl);
            }
        }
        #endregion
        //All other control things are in the region open it
        #region Other Controls
        private void button_Animals_Home_Click(object sender, EventArgs e)
        {
            Home HomeForm = new Home(employeeManager);
            this.Hide(); HomeForm.Show();
        }

        private void button_Animals_Employees_Click(object sender, EventArgs e)
        {
            Employees empForm = new Employees(employeeManager);
            this.Hide(); empForm.Show();
        }
        private void Animals_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                switch (MessageBox.Show(this, "Close Application?", "Closing",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes: Application.Exit(); break;
                    case DialogResult.No: e.Cancel = true; break;
                }
            }
        }
        private void Animals_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void button_Animals_Logout_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Want To Logout?", "Logging Out",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Login LoginForm = new Login();
                    LoginForm.Show(); this.Hide(); ; break;
                case DialogResult.No: break;
            }
        }
        #endregion
        private void button_Animals_Exhibits_Click(object sender, EventArgs e)
        {
            Exhibits ExhibitsForm = new Exhibits();
            this.Hide(); ExhibitsForm.Show();
        }

        private void button_Zones_Click(object sender, EventArgs e)
        {
            Zones ZonesForm = new Zones();
            this.Hide(); ZonesForm.Show();
        }

        private void button_ZooPartner_Click(object sender, EventArgs e)
        {
            ZooPartnerForm zooPartnerForm = new ZooPartnerForm();
            this.Hide(); zooPartnerForm.Show();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            UpdateAnimalControlAll();
        }

        private void btnEditFilter_Click(object sender, EventArgs e)
        {
            UpdateAnimalControlSpecies();
        }
        private void button_AddAnimal_Click(object sender, EventArgs e)
        {
            AddAnimal AddAnimalForm = new AddAnimal(this);
            this.Hide(); AddAnimalForm.Show();
        }
    }
 }