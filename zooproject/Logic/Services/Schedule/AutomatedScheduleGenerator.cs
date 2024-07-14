using Domain.Domain.Feeding;
using Infrastructure.Databases.Feeding;
using Logic.Services.Zoo;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Animals;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Logic.Services.User;
using zooproject.Logic.Services.Zoo;

namespace Logic.Services.Schedule
{
    public class AutomatedScheduleGenerator
    {
        FeedingManager feedingManager;
        AnimalManager animalManager;
        EmployeeManager employeeManager;

        public AutomatedScheduleGenerator()
        {
            feedingManager = new FeedingManager(new FeedingDB());
            animalManager = new AnimalManager(new AnimalDB());
            employeeManager = new EmployeeManager(new DBEmployees());
        }

        public List<FeedingTask> GenerateTasks(DateTime start, DateTime end, List<Animal> animals)
        {
            DateTime Start = start;
            DateTime End = end;
            List<Animal> Animals = animals;
            List<FeedingTask> tasks = new List<FeedingTask>();
            int days = Calculator.CalculateAmountOfDays(Start, End);
            foreach (Animal animal in Animals)
            {
                List<FeedingTask> existingtasks = feedingManager.GetTaskByDateAndAnimal(Start, End, animal.IDAuto);
                DateTime taskdate = Start;
                double amount = Calculator.CalculateAmountOfTasks(Start, End, animal.FeedingPeriod);
                int interval = (int)Math.Round(days / amount);
                for(int i = 0; i <= amount; i++)
                {
                    if(existingtasks.Count == 0)
                    {
                        
                        FeedingTask feedingtask = new FeedingTask(animal.exhibitID, taskdate, animal.PreferedSlot, 3, animal.IDAuto);
                        feedingManager.AddFeedingTask(feedingtask);
                        tasks.Add(feedingtask);
                        taskdate = taskdate.AddDays(interval);
                       
                    }
                    else if (existingtasks.Count > 0)
                    {
                        List<FeedingTask> templist = existingtasks.ToList();
                        foreach (FeedingTask existingtask in templist)
                        {
                            if (existingtask.FeedingDate != taskdate)
                            {
                                FeedingTask feedingtask = new FeedingTask(animal.exhibitID, taskdate, animal.PreferedSlot, 3, animal.IDAuto);
                                feedingManager.AddFeedingTask(feedingtask);
                                tasks.Add(feedingtask);
                                
                            }
                            taskdate.Date.AddDays(interval);
                        }
                    }
                    
                }
            }
            return tasks;
        }

        public void AssignEmployees( DateTime start, DateTime end)
        {
            // Get Generated Tasks
            List<FeedingTask> tasks = feedingManager.GetAllFeedingTasks(start, end);
            //First Get Employees based on the tasks species
            foreach (var task in tasks)
            {
                List<Employee> activeEmployees = employeeManager.GetActiveEmployee(task.FeedingDate);
                int workedHours = 0;
                foreach (var employee in activeEmployees.ToList())
                {
                    if(employee.Specialication != animalManager.ReadByID(task.AnimalID).Species.ToString() )
                    {
                        activeEmployees.Remove(employee);
                    }
                }

                if (activeEmployees.Count > 0)
                {
                    for (int i = 0; i < task.EmployeeLimit; i++)
                    {
                        if (i < activeEmployees.Count)
                        {
                            if (task.EmployeeIDs.Contains(activeEmployees[i].Id))
                            {
                                activeEmployees.Remove(activeEmployees[i]);
                            }
                            else
                            {
                                List<Employee> employeesAssignedOnDate = employeeManager.GetEmployeesByTaskAndDates(task.ID, start, end);
                                int count = employeesAssignedOnDate.Where(x => x.Equals(activeEmployees[i])).Count();
                                workedHours = count * 5;

                                if (workedHours < activeEmployees[i].ContractHours)
                                {
                                    task.EmployeeIDs.Add(activeEmployees[i].Id);
                                    feedingManager.AssignEmployee(task, activeEmployees[i]);
                                }
                            }

                                
                        }
                        

                    }
                }
                // Then check the hours the employee has worked and Assign Employee 
                
                
            }
        }
    }
}