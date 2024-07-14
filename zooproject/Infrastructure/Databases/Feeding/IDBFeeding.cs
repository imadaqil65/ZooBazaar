using Domain.Domain.Feeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;

namespace Infrastructure.Databases.Feeding
{
    public  interface IDBFeeding
    {
        public void AddFeedingTask(FeedingTask feedingTask);
        public void AssignEmployee(FeedingTask feedingTask, Employee employee);
        public void UpdateFeedingTask(FeedingTask feedingTask);
        public void DeleteFeedingTask(FeedingTask feedingTask);
        public List<FeedingTask> GetAllFeedingTasks(DateTime first, DateTime last);
        public List<FeedingTask> GetFeedingTaskByID(int id);
        public List<Employee> GetTaskEmployees(int id);
        public bool GetTaskByDateBool(DateTime feedingDate, int id);
        public List<FeedingTask> GetTaskByDateAndAnimal(DateTime start, DateTime end, int animalID);
        public List<FeedingTask> GetFeedingTaskByDatesAndAnimalSpecies(DateTime start, DateTime end, AnimalSpecies animalSpecies);


    }
}
