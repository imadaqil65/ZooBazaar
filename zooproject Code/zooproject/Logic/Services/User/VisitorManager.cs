using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.User;
using zooproject.Infrastructure.Databases.Employees;
using zooproject.Infrastructure.Databases.Visitors;
namespace zooproject.Logic.Services.User
{
    public class VisitorManager
    {
        IDBVisitor datasource;

        public VisitorManager(IDBVisitor source)
        {
            datasource = source;
        }
        public List<Visitor> GetVisitor()
        {
            List<Visitor> Listy = new List<Visitor>();
            return Listy;
        }

        public void CreateVisitor(Visitor visitor)
        {
            datasource.AddVisitor(visitor);
        }
        public void RemoveVisitor(Visitor visitor)
        {

        }
    }
}