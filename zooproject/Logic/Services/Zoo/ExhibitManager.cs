using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Exhibits;
using zooproject.Infrastructure.Databases.Animals;

namespace zooproject.Logic.Services.Zoo
{
    public class ExhibitManager
    {
        IExhibitDB datasource;
        public ExhibitManager(IExhibitDB source)
        {
            datasource = source;
        }
        public void CreateExhibit(string name, bool predatoryorprey, EnviromentType exhibittype, int zoneID)
        {
            Exhibit newExhibit = new Exhibit(name, predatoryorprey, exhibittype, zoneID);
            datasource.AddExhibit(newExhibit);
        }

        public List<Exhibit> ReadAllExhibits()
        {
            List<Exhibit> result = datasource.ReadAllExhibits();
            return result;

        }
        public void EditExhibit(Exhibit exhibit)
        {
            datasource.UpdateExhibit(exhibit);
        }
        public void DeleteExhibit(Exhibit exhibit)
        {
            datasource.DeleteExhibit(exhibit);
        }
        public Exhibit GetByID(int id)
        {
            Exhibit result = datasource.ReadExhibitByID(id);
            return result;
        }
        public void SetMaxAnimals(int maxanimals, Exhibit exhibit)
        {
			AnimalManager animalManager = new AnimalManager(new AnimalDB());
            if (maxanimals > animalManager.ReadByExhibit(exhibit).Count)
            {
                exhibit.SetMaxAnimals(maxanimals);
            }
            else
            {
                throw new Exception("New max is lower than animals currently in the exhibit!"); //Need to implement custom exception here
            }
		}
	}
}