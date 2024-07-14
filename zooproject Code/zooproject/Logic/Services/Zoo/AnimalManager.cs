using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.Zoo;
using zooproject.Domain.Domain.Exceptions;
using zooproject.Infrastructure.Databases.Animals;

namespace zooproject.Logic.Services.Zoo
{
    public class AnimalManager
    {
        IAnimalDB datasource;
        public AnimalManager(IAnimalDB source)
        {
            datasource = source;
        }
        public List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();
            foreach (Animal animal in datasource.ReadAllAnimals())
            {
                animals.Add(animal);
            }
            return animals;
        }
        public void CreateAnimal(string name, AnimalSpecies species, DateTime enterdate, string origin, Gender gender, DateTime dateOfBirth, string diet, string notes, string relations, int exhibitID, bool isPredator, bool isPrey)
        {
            if (string.IsNullOrEmpty(name)) { throw new DomainException("Name Was Empty"); }
            Animal newAnimal = new Animal(name, species, enterdate, origin, gender, dateOfBirth, diet, notes, relations, exhibitID, isPredator, isPrey);
            datasource.AddAnimal(newAnimal);
        }
        public Exhibit GetExhibit(int exhibitID)
        {
            return datasource.GetExhibit(exhibitID);
        }

        public void CreateRemovedAnimal(Animal animal)
        {
            datasource.AddAnimal(animal);
        }
        public void UpdateAnimal(Animal animal)
        {

            datasource.UpdateAnimal(animal);
        }
        public void RemoveAnimal(Animal animal)
        {
            datasource.DeleteAnimal(animal);
        }

        public List<Animal> ReadAllAnimals()
        {
            List<Animal> result = datasource.ReadAllAnimals();
            return result;
        }

        public List<Animal> ReadBySpecies(AnimalSpecies species)
        {
            List<Animal> results = datasource.GetBySpecies(species);
            return results;

        }

        public List<Animal> ReadByExhibit(Exhibit exhibit)
        {
            List<Animal> result = datasource.GetByExhibit(exhibit);
            return result;
        }

        public Animal ReadByID(int id)
        {
            Animal result = datasource.GetByID(id);
            return result;
        }

    }

}