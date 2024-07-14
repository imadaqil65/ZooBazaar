using zooproject.Domain.Domain.User;

namespace zooproject.Infrastructure.Databases.Visitors
{
    public interface IDBVisitor
    {
        public void AddVisitor(Visitor v);
        public void DeleteVisitor(Visitor v);
        public void UpdateVisitor(Visitor v);
        public List<Visitor> ReadAllVisitors();
        public Visitor SearchVisitorById(int id);
        public bool CheckEmail(string email);
    }
}