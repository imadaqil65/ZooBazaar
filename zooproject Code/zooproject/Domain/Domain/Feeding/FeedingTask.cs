using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;

namespace Domain.Domain.Feeding
{
    public class FeedingTask
    {
        private readonly int  id;
        public int ID => id;
        public int ExhibitID { get; set; }
        public DateTime FeedingDateTime { get; set; }
        public int AnimalID { get; set; }

        /// <summary>
        /// New Feeding Task
        /// </summary>
        /// <param name="exhibitID"></param>
        /// <param name="feedingDateTime"></param>
        /// <param name="animalID"></param>
        public FeedingTask(int exhibitID, DateTime feedingDateTime, int animalID)
        {
            ExhibitID = exhibitID;
            FeedingDateTime = feedingDateTime;
            AnimalID = animalID;
        }
        /// <summary>
        /// For unexplained error and demo
        /// </summary>
        /// <param name="exhibitID"></param>
        /// <param name="feedingDateTime"></param>
        public FeedingTask(int exhibitID, DateTime feedingDateTime)
        {
            ExhibitID = exhibitID;
            FeedingDateTime = feedingDateTime;
        }
        /// <summary>
        /// Read exhisting Feeding Task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exhibitID"></param>
        /// <param name="feedingDateTime"></param>
        /// <param name="animalID"></param>
        public FeedingTask(int id, int exhibitID, DateTime feedingDateTime, int animalID)
        {
            this.id = id;
            ExhibitID= exhibitID;
            FeedingDateTime = feedingDateTime;
            AnimalID = animalID;
        }   
    }
}
