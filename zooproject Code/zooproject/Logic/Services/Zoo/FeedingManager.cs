using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Feeding;
using Infrastructure.Databases.Feeding;

namespace Logic.Services.Zoo
{
    
    public class FeedingManager
    {
        private IDBFeeding datasource;

        public FeedingManager(IDBFeeding source)
        {
            datasource = source;
        }

        public void AddFeedingTask(FeedingTask feedingTask)
        {
            datasource.AddFeedingTask(feedingTask);
        }

        public void UpdateFeedingTask(FeedingTask feedingTask)
        {
            datasource.UpdateFeedingTask(feedingTask);
        }

        public void DeleteFeedingTask(FeedingTask feedingTask)
        {
            datasource.DeleteFeedingTask(feedingTask);
        }

        public List<FeedingTask> GetAllFeedingTasks()
        {
            List<FeedingTask> results = datasource.GetAllFeedingTasks();
            return results;
        }

        public List<FeedingTask> GetFeedingTaskById(int id)
        {
            List<FeedingTask> results = datasource.GetFeedingTaskByID(id);
            return results;
        }
    }
}
