namespace zooproject.Domain.Domain.User
{
    public class WorkAssignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AssignmentDate { get; set; }
        public Rank RequiredRank { get; set; }
        public int AssignedExhibitId { get; set; }
        public int AssignedEmployeeId { get; set; }

        public WorkAssignment(string name, DateTime assignmentdate, Rank requiredrank, int exhibitid)
        {
            Name = name;
            AssignmentDate = assignmentdate;
            RequiredRank = requiredrank;
            AssignedExhibitId = exhibitid;
        }
        public WorkAssignment(int id, string name, DateTime assignmentdate, Rank requiredrank, int exhibitid)
        {
            Id = id;
            Name = name;
            AssignmentDate = assignmentdate;
            RequiredRank = requiredrank;
            AssignedExhibitId = exhibitid;
        }
        public WorkAssignment(int id, string name, DateTime assignmentdate, Rank requiredrank, int exhibitid, int employeeid)
        {
            Id = id;
            Name = name;
            AssignmentDate = assignmentdate;
            RequiredRank = requiredrank;
            AssignedExhibitId = exhibitid;
            AssignedEmployeeId = employeeid;
        }
    }
}