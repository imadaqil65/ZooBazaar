using zooproject.Domain.Domain.User;
using zooproject.Infrastructure.Databases.WorkAssignments;

namespace zooproject.Logic.Services.User
{
    public class WorkAssignmentManager
    {
        IDBWorkAssignment datasource;
        public WorkAssignmentManager(IDBWorkAssignment source)
        {
            datasource = source;
        }
        public void CreateWorkAssignment(string name, DateTime assignmentdate, Rank requiredrank, int exhibitid)
        {
            WorkAssignment newWorkAssignment = new WorkAssignment(name, assignmentdate, requiredrank, exhibitid);
            datasource.AddWorkAssignment(newWorkAssignment);
        }
        public List<WorkAssignment> GetAllWorkAssignments()
        {
            List<WorkAssignment> works = new List<WorkAssignment>();
            foreach (WorkAssignment work in datasource.ReadAllWorkAssignments())
            {
                works.Add(work);
            }
            return works;
        }
        public void UpdateWorkAssignmentData(WorkAssignment work)
        {
            datasource.UpdateWorkAssignment(work);
        }
        public void RemoveWorkAssignment(WorkAssignment work)
        {
            datasource.DeleteWorkAssignment(work);
        }
    }
}