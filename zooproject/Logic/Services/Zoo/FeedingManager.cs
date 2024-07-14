using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Feeding;
using Infrastructure.Databases.Feeding;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;

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

        public List<FeedingTask> GetAllFeedingTasks(DateTime first, DateTime last)
        {
            List<FeedingTask> results = datasource.GetAllFeedingTasks(first, last);
            return results;
        }

        public List<FeedingTask> GetFeedingTaskById(int id)
        {
            List<FeedingTask> results = datasource.GetFeedingTaskByID(id);
            return results;
        }

        public List<Employee> GetTaskEmployees(int id)
        {
            List<Employee> results = datasource.GetTaskEmployees(id);
            return results;
        }
        public void AssignEmployee(FeedingTask feedingTask, Employee employee)
        {
            datasource.AssignEmployee(feedingTask, employee);
        }
        public bool GetTaskByDateBool(DateTime feedingDate, int id)
        {
            return datasource.GetTaskByDateBool(feedingDate, id);
        }

        public List<FeedingTask> GetTaskByDateAndAnimal(DateTime start, DateTime end, int animalID)
        {
            return datasource.GetTaskByDateAndAnimal(start, end, animalID);
        }
        public List<FeedingTask> GetFeedingTaskByDatesAndAnimal(DateTime start, DateTime end, AnimalSpecies animalSpecies)
        {
            return datasource.GetFeedingTaskByDatesAndAnimalSpecies(start, end, animalSpecies);
        }
    }
}
