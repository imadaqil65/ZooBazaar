using Domain.Domain.Feeding;
using Infrastructure.Databases.Feeding;
using Logic.Services.Zoo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Logic.Services.User;
using zooproject.User_Controls;

namespace zooproject
{
    public partial class FeedingSchedule : Form
    {
        FeedingManager fm;
        public FeedingSchedule()
        {
            InitializeComponent();
            fm = new FeedingManager(new FeedingDB());
        }
        // Button controls are in region
        #region Button Controls
        private void button_Feeding_Home_Click(object sender, EventArgs e)
        {
            Home home = new Home(new EmployeeManager(new DBEmployees()));
            this.Hide(); home.Show();
        }

        private void button_AddTask_Click(object sender, EventArgs e)
        {
            AddFeedingTask addFeedingTask = new AddFeedingTask();
            addFeedingTask.Show();
        }
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            FillDataView(fm.GetAllFeedingTasks());
        }
        //TODO: Make Filters
        private void btnEditFilter_Click(object sender, EventArgs e)
        {

        }
        #endregion
        //Methods relating to the user controls are in the region
        #region User Control Methods
        private void ClearFlowLayout()
        {
            flpMonday.Controls.Clear();
            flpTuesday.Controls.Clear();
            flpWednesday.Controls.Clear();
            flpThursday.Controls.Clear();
            flpFriday.Controls.Clear();
            flpSaturday.Controls.Clear();
            flpSunday.Controls.Clear();
        }
        private void FillDataView(List<FeedingTask> results)
        {
            ClearFlowLayout();
            foreach (FeedingTask result in results)
            {
                switch (result.FeedingDateTime.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        flpMonday.Controls.Add(new FeedingTaskControl(result,this));
                        break;
                    case DayOfWeek.Tuesday:
                        flpTuesday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Wednesday:
                        flpWednesday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Thursday:
                        flpThursday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Friday:
                        flpFriday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Saturday:
                        flpSaturday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    case DayOfWeek.Sunday:
                        flpSunday.Controls.Add(new FeedingTaskControl(result, this));
                        break;
                    default:
                        // code block
                        break;
                }
            }
        }

        #endregion

    }
}
