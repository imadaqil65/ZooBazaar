using Domain.Domain.Enums;
using Domain.Domain.Feeding;
using Infrastructure.Databases.Feeding;
using Logic.Services.Zoo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;

namespace zooproject
{
    public partial class AddFeedingTask : Form
    {
        ExhibitManager exhibitManager;
        EmployeeManager employeeManager;
        AnimalManager animalManager;
        FeedingManager feedingManager;
        public Employee selectedEmployee;
        public Exhibit selectedExhibit;

        public AnimalExhibitControl? selectedAnimalExhibitControl;
        public EmployeeSelectControl? selectedEmployeeSelectControl;

        public AddFeedingTask()
        {
            InitializeComponent();
            exhibitManager = new ExhibitManager(new ExhibitDB());
            employeeManager = new EmployeeManager(new DBEmployees());
            animalManager = new AnimalManager(new AnimalDB());
            feedingManager = new FeedingManager(new FeedingDB());
            FillExhibitBox();
            FillComboBox();
        }

        #region Buttons


        private void btnReloadExhibit_Click(object sender, EventArgs e)
        {
            FillExhibitBox();
        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            feedingManager.AddFeedingTask(new FeedingTask(selectedExhibit.Id, dtpDateTime.Value.Date, (FeedingTimeSlot)cboxFeedingTimeSlot.SelectedIndex, Convert.ToInt32(numEmployeeLimit.Value), animalManager.ReadByExhibit(selectedExhibit).FirstOrDefault().IDAuto));
            this.Close();
        }
        #endregion

        #region FlowLayout
        private void FillComboBox()
        {
            cboxFeedingTimeSlot.DataSource = Enum.GetValues(typeof(FeedingTimeSlot));
        }
        private void FillExhibitBox()
        {
            flpAnimalExibits.Controls.Clear();
            List<Exhibit> results = FeedingSpeciesFilter(exhibitManager.ReadAllExhibits());
            foreach (var result in results)
            {

                AnimalExhibitControl exhibitControl = new AnimalExhibitControl(result, this);
                flpAnimalExibits.Controls.Add(exhibitControl);
            }
        }

        private List<Exhibit> FeedingSpeciesFilter(List<Exhibit> exhibits)
        {
            List<Exhibit> filteredExhibits = new List<Exhibit>();
            foreach (var result in exhibits)
            {

                if (animalManager.ReadByExhibit(result).FirstOrDefault().Species != null)
                {
                    DateTime checkDate = dtpDateTime.Value.Date;
                    bool sameDayTask = feedingManager.GetTaskByDateBool(checkDate, result.Id);
                    if ( sameDayTask == false)
                    {
                        if (animalManager.ReadByExhibit(result).FirstOrDefault().Species == AnimalSpecies.Lion || animalManager.ReadByExhibit(result).FirstOrDefault().Species == AnimalSpecies.Elephant || animalManager.ReadByExhibit(result).FirstOrDefault().Species == AnimalSpecies.Rhino || animalManager.ReadByExhibit(result).FirstOrDefault().Species == AnimalSpecies.Tiger || animalManager.ReadByExhibit(result).FirstOrDefault().Species == AnimalSpecies.Giraffe || animalManager.ReadByExhibit(result).FirstOrDefault().Species == AnimalSpecies.Ostrich || animalManager.ReadByExhibit(result).FirstOrDefault().Species == AnimalSpecies.Shark || animalManager.ReadByExhibit(result).FirstOrDefault().Species == AnimalSpecies.Gorilla)
                        {

                            bool existingtask = feedingManager.GetTaskByDateBool(checkDate.AddDays(-1), result.Id);

                            if (existingtask == false && sameDayTask == false)
                            {
                                filteredExhibits.Add(result);
                            }
                        }
                        else
                        {
                            filteredExhibits.Add(result);
                        }
                    }
                    
                }
                
            }


            return filteredExhibits;
        }

        #endregion


        public void RememberSelectedAnimalExhibitControl(AnimalExhibitControl animalexhibitcontrol)
        {
            selectedAnimalExhibitControl = animalexhibitcontrol;
        }
        public void RememberSelectedEmployeeSelectControl(EmployeeSelectControl employeeselectcontrol)
        {
            selectedEmployeeSelectControl = employeeselectcontrol;
        }

        private void ValueUpdated(object sender, EventArgs e)
        {
            FillExhibitBox();
        }
    }
}
