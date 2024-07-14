using zooproject.Domain.Domain.Zoo;

namespace zooproject.Infrastructure.Databases.Exhibits
{
    public interface IExhibitDB
    {
        public void AddExhibit(Exhibit e);
        public void DeleteExhibit(Exhibit e);
        public void UpdateExhibit(Exhibit e);
        public List<Exhibit> ReadAllExhibits();
        public Exhibit ReadExhibitByID(int id);
    }
}