using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Events
{
    public class TaskFilterEvent
    {
        public delegate void TaskFilterEventHandler(DateTime start, DateTime end, AnimalSpecies animalSpecies);

        public event TaskFilterEventHandler taskEvent;
        public TaskFilterEvent() { }
        public void SentFilteredAnimals(DateTime start, DateTime end, AnimalSpecies animalSpecies)
        {
            taskEvent(start,end,animalSpecies);
        }
    }
}
