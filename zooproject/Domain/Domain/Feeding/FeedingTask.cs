using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Enums;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;

namespace Domain.Domain.Feeding
{
    public class FeedingTask
    {
        private readonly int  id;
        public int ID => id;
        public int ExhibitID { get; set; }
        public DateTime FeedingDate { get; set; }
        public FeedingTimeSlot FeedingTimeSlot { get; set; }
        public List<int> EmployeeIDs { get; set; }
        public int EmployeeLimit { get; set; }
        public int AnimalID { get; set; }


        /// <summary>
        /// New Feeding Task without employees
        /// </summary>
        /// <param name="exhibitID"></param>
        /// <param name="feedingDate"></param>
        /// <param name="feedingTimeSlot"></param>
        public FeedingTask(int exhibitID, DateTime feedingDate, FeedingTimeSlot feedingTimeSlot, int employeeLimit, int animalID)
        {
            ExhibitID = exhibitID;
            FeedingDate = feedingDate;
            FeedingTimeSlot = feedingTimeSlot;
            EmployeeLimit = employeeLimit;
            AnimalID = animalID;
        }
        

        /// <summary>
        /// Read new FeedingTask
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exhibitID"></param>
        /// <param name="feedingDateTime"></param>
        /// <param name="feedingTimeSlot"></param>
        /// <param name="employeeLimit"></param>
        /// <param name="employeeIDs"></param>
        public FeedingTask(int id, int exhibitID, DateTime feedingDateTime, FeedingTimeSlot feedingTimeSlot, int employeeLimit, List<int> employeeIDs,int animalID)
        {
            this.id = id;
            ExhibitID= exhibitID;
            FeedingDate = feedingDateTime;
            FeedingTimeSlot = feedingTimeSlot;
            EmployeeLimit = employeeLimit;
            EmployeeIDs = employeeIDs;
            AnimalID = animalID;
        }

        public FeedingTask(int id, int exhibitID, DateTime feedingDateTime, FeedingTimeSlot feedingTimeSlot, int employeeLimit, int animalID)
        {
            this.id = id;
            ExhibitID = exhibitID;
            FeedingDate = feedingDateTime;
            FeedingTimeSlot = feedingTimeSlot;
            EmployeeLimit = employeeLimit;
            AnimalID = animalID;
        }
    }
}
