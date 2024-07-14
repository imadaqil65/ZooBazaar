using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Exhibits;

namespace zooproject.Logic.Services.Zoo
{
    public class ExhibitManager
    {
        IExhibitDB datasource;
        public ExhibitManager(IExhibitDB source)
        {
            datasource = source;
        }
        public void CreateExhibit(string name, bool predatoryorprey, EnviromentType exhibittype)
        {
            Exhibit newExhibit = new Exhibit(name, predatoryorprey, exhibittype);
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
    }
}