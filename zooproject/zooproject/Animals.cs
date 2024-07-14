using zooproject.Domain.Domain.Zoo;
using zooproject.Domain.Domain.Exceptions;
using zooproject.Events;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Infrastructure.Databases.Zones;
using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;
using static zooproject.Events.AnimalFilterEvent;
using Domain.Domain.Exceptions;

namespace zooproject
{
	public partial class Animals : Form
	{
		AnimalFilterEvent animalFilterEvent;

		Exhibit selectedExhibit;
		Animal selectedAnimal;

		internal Zone selectedZone;
		internal Animal animalToBeRemoved;
		AnimalManager animalmanager;
		AnimalManager removedAnimalManager;
		ExhibitManager exhibitManager;
		EmployeeManager employeeManager;
		ZoneManager zoneManager;
		public AnimalFilters? animalFilters;
		public Exhibit animalExhibit { get; set; }

		public Animals(EmployeeManager employeemanager)
		{
			InitializeComponent();
			employeeManager = employeemanager;
			InstantiateManagerClasses();
            UpdateAnimalControlAll();
        }
		private void InstantiateManagerClasses()
		{
			animalmanager = new AnimalManager(new AnimalDB()); //Is going to get moved to the LoginForm instead
			//removedAnimalManager = new AnimalManager(new RemovedAnimalDB());
			exhibitManager = new ExhibitManager(new ExhibitDB());
			zoneManager = new ZoneManager(new ZoneDB());
		}
		//All Animal CRUD things are in the region, open it
		#region Animal Controls

		public void UpdateAnimalControlAll()
		{
			try
			{
                flpAnimals.Controls.Clear();
                foreach (var result in animalmanager.ReadAllAnimals())
                {
                    AnimalControl animalControl = new AnimalControl(result, this);
                    flpAnimals.Controls.Add(animalControl);
                }
            }
			catch (NoConnectionException Ex)
			{
				MessageBox.Show(Ex.Message);
				Console.WriteLine(Ex);
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
				Console.WriteLine(Ex);
			}
		}
		public void UpdateAnimalControlFiltered(int animalspecies, int animalenviroment, int exhibitid, bool Predator, bool Prey)
		{
			flpAnimals.Controls.Clear();
			AnimalManager animalManager = new AnimalManager(new AnimalDB());

			int animalSpecies = animalspecies;
			int animalEnviroment = animalenviroment;
			int exhibitID = exhibitid;
			bool predator = Predator;
			bool prey = Prey;
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
				AnimalControl animalControl = new AnimalControl(animal, this);
				flpAnimals.Controls.Add(animalControl);
			}
		}
		#endregion
		//All other control things are in the region open it
		#region Other Controls
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
		#endregion
		private void SetAnimalFilterEvent()
		{
			animalFilterEvent = new AnimalFilterEvent();
			animalFilterEvent.animalEvent += new AnimalFilterEventHandler(this.UpdateAnimalControlFiltered);
		}
		private void button_CreateAnimal_Click_1(object sender, EventArgs e)
		{
			AddAnimal AddAnimalForm = new AddAnimal(this);
			AddAnimalForm.Show();
		}
		private void button_GetAll_Click_1(object sender, EventArgs e)
		{
			UpdateAnimalControlAll();
		}
		private void button_Filter_Click(object sender, EventArgs e)
		{
			if(animalFilters == null)
			{
                animalFilters = new AnimalFilters(this);
                this.SetAnimalFilterEvent();
                animalFilters.StartPosition = FormStartPosition.Manual;
                animalFilters.Location = new Point(this.Location.X + 889, this.Location.Y);
                animalFilters.Show();
            }
		}
		private void button_Animals_Home_Click_1(object sender, EventArgs e)
		{
			Home HomeForm = new Home(employeeManager);
            HomeForm.StartPosition = FormStartPosition.Manual;
            HomeForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); HomeForm.Show();
		}
		private void button_Animals_Employees_Click_1(object sender, EventArgs e)
		{
            Employees empForm = new Employees(employeeManager);
            empForm.StartPosition = FormStartPosition.Manual;
            empForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); empForm.Show();
        }
		private void button_Animals_Exhibits_Click_1(object sender, EventArgs e)
		{
            Exhibits ExhibitsForm = new Exhibits();
            ExhibitsForm.StartPosition = FormStartPosition.Manual;
            ExhibitsForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); ExhibitsForm.Show();
        }
		private void button_Zones_Click_1(object sender, EventArgs e)
		{
            Zones ZonesForm = new Zones();
            ZonesForm.StartPosition = FormStartPosition.Manual;
            ZonesForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); ZonesForm.Show();
        }
		private void button_ZooPartner_Click_1(object sender, EventArgs e)
		{
            ZooPartnerForm zooPartnerForm = new ZooPartnerForm();
            zooPartnerForm.StartPosition = FormStartPosition.Manual;
            zooPartnerForm.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); zooPartnerForm.Show();
        }
		private void button_Animals_Logout_Click_1(object sender, EventArgs e)
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
		private void button_FeedingSchedule_Click(object sender, EventArgs e)
		{
            FeedingSchedule feedingSchedule = new FeedingSchedule();
            feedingSchedule.StartPosition = FormStartPosition.Manual;
            feedingSchedule.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); feedingSchedule.Show();
        }

        private void button_TicketStatistics_Click(object sender, EventArgs e)
        {
			TicketStatistics ticketStatistics = new TicketStatistics();
            ticketStatistics.StartPosition = FormStartPosition.Manual;
            ticketStatistics.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide(); ticketStatistics.Show();
        }
    }
}