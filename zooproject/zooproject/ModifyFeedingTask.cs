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
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;
using zooproject.User_Controls;

namespace zooproject
{
    public partial class ModifyFeedingTask : Form
    {
        FeedingTask feedingTask;
        ExhibitManager em;
        AnimalManager am;
        EmployeeManager epm;
        FeedingManager fm;
        public Employee selectedEmployee;

        public EmployeeSelectControl? selectedEmployeeSelectControl;
        public ModifyFeedingTask(FeedingTask inputFeedingTask)
        {
            InitializeComponent();
            this.feedingTask = inputFeedingTask;
            em = new ExhibitManager(new ExhibitDB());
            am = new AnimalManager(new AnimalDB());
            epm = new EmployeeManager(new DBEmployees());
            fm = new FeedingManager(new FeedingDB());
            lblExhibit.Text = "Exhibit: " + em.GetByID(feedingTask.ExhibitID).Name;
            lblSpecies.Text = "Species: " + am.ReadByID(feedingTask.AnimalID).Species.ToString();
            lblDiet.Text = "Diet: " + am.ReadByID(feedingTask.AnimalID).Diet;
            lblEmployeeLimit.Text = "Total Employees Needed: " + feedingTask.EmployeeLimit;
            FillEmployeePanel();
            FillAssignedEmployeePanel();
        }

        // Button Controls are in region
        #region Buttons
        private void btnReload_Click(object sender, EventArgs e)
        {
            FillEmployeePanel();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (feedingTask.EmployeeIDs.Count == 0 || feedingTask.EmployeeIDs.Count < feedingTask.EmployeeLimit)
            {
                feedingTask.EmployeeIDs.Add(selectedEmployee.Id);
                fm.AssignEmployee(feedingTask, selectedEmployee);
                flpAssignedEmp.Controls.Add(selectedEmployeeSelectControl);
            }
            else
            {
                switch (MessageBox.Show(this, "Number of Employees has been reached. Do you want to assign another?", "Limit Reached",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        feedingTask.EmployeeIDs.Add(selectedEmployee.Id);
                        fm.AssignEmployee(feedingTask, selectedEmployee);
                        flpAssignedEmp.Controls.Add(selectedEmployeeSelectControl); ; break;
                    case DialogResult.No: break;
                }
            }


        }
        private void btnReloadAssigned_Click(object sender, EventArgs e)
        {
            FillAssignedEmployeePanel();
        }
        #endregion

        #region FlowControls

        private void FillEmployeePanel()
        {
            flpEmployees.Controls.Clear();
            foreach (var result in epm.GetEmployeesBySpecialization(am.ReadByID(feedingTask.AnimalID)))
            {
                EmployeeSelectControl employeeSelectControl = new EmployeeSelectControl(result, this);
                flpEmployees.Controls.Add(employeeSelectControl);
            }
        }
        private void FillAssignedEmployeePanel()
        {
            flpAssignedEmp.Controls.Clear();
            foreach (var result in fm.GetTaskEmployees(feedingTask.ID))
            {
                EmployeeSelectControl employeeSelectControl = new EmployeeSelectControl(result, this);
                flpAssignedEmp.Controls.Add(employeeSelectControl);
            }
        }
        #endregion

        public void RememberSelectedEmployeeSelectControl(EmployeeSelectControl employeeselectcontrol)
        {
            selectedEmployeeSelectControl = employeeselectcontrol;
        }


    }
}
