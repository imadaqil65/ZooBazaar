using zooproject.Domain.Domain.User;

namespace zooproject.Infrastructure.Databases.WorkAssignments
{
    public interface IDBWorkAssignment
    {
        public void AddWorkAssignment(WorkAssignment workAssignment);
        public void DeleteWorkAssignment(WorkAssignment workAssignment);
        public void UpdateWorkAssignment(WorkAssignment workAssignment);
        public List<WorkAssignment> ReadAllWorkAssignments();
    }
}