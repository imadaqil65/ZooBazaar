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
            return datasource.ReadAllVisitors();
        }

        public void CreateVisitor(Visitor visitor)
        {
            datasource.AddVisitor(visitor);
        }
        public void RemoveVisitor(Visitor visitor)
        {

        }

        public Visitor GetVisitorById(int id)
        {
            return datasource.SearchVisitorById(id);
        }

        public void EditVisitor(Visitor visitor)
        {
            datasource.UpdateVisitor(visitor);
        }

        public bool EmailCheck(string email)
        {
            return datasource.CheckEmail(email);
        }
    }
}