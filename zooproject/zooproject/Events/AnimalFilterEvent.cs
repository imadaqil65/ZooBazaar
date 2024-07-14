using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;
using zooproject.User_Controls;


namespace zooproject.Events
{
	public class AnimalFilterEvent
	{
		public delegate void AnimalFilterEventHandler(int animalspecies, int animalenviroment, int exhibitid, bool Predator, bool Prey);

		public event AnimalFilterEventHandler animalEvent;
		public AnimalFilterEvent() { }
		public void SentFilteredAnimals(int animalspecies, int animalenviroment, int exhibitid, bool Predator, bool Prey)
		{
			animalEvent(animalspecies, animalenviroment, exhibitid, Predator, Prey);
		}
	}
}