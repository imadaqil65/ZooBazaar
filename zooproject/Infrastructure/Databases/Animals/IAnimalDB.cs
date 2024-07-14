using zooproject.Domain.Domain.Zoo;

namespace zooproject.Infrastructure.Databases.Animals
{
    public interface IAnimalDB
    {

        public void AddAnimal(Animal a, int b);
        public void DeleteAnimal(Animal a);
        public void UpdateAnimal(Animal a);
        public List<Animal> ReadAllAnimals();
        public List<Animal> GetBySpecies(AnimalSpecies species);
        public List<Animal> GetByExhibit(Exhibit exhibit);
        public Exhibit GetExhibit(int id);
        public Animal GetByID(int id);

    }
}