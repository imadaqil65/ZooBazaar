using Domain.Domain.Feeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;

namespace Infrastructure.Databases.Feeding
{
    public  interface IDBFeeding
    {
        public void AddFeedingTask(FeedingTask feedingTask);
        public void UpdateFeedingTask(FeedingTask feedingTask);
        public void DeleteFeedingTask(FeedingTask feedingTask);
        public List<FeedingTask> GetAllFeedingTasks();
        public List<FeedingTask> GetFeedingTaskByID(int id);
        
    }
}
