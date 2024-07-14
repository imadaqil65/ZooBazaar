using zooproject.Domain.Domain.Enums;
namespace zooproject.Domain.Domain.User
{           
    public class Employee : User
    {
        public JobType Job { get; set; }
        public Rank UserRank { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Fired { get; set; }
        public bool Retired { get; set; }

        public Employee()
        {

        }
        public Employee(JobType job, Rank rank, DateTime startDate, string firstname, string lastname, int phoneNumber, Gender usergender, int bSN, string email, string username, string password, DateTime birthdate, string specialication) : base(firstname, lastname, phoneNumber, usergender, bSN, email, username, password, birthdate, specialication)
        {
            Job = job;
            UserRank = rank;
            StartDate = startDate;
        }

        public Employee(JobType job, Rank rank, DateTime startDate, int id, string firstname, string lastname, int phoneNumber, Gender usergender, int bSN, string email, string username, string password, DateTime birthdate, string specialication) : base(id,firstname, lastname, phoneNumber, usergender, bSN, email, username, password, birthdate, specialication)
        {
            Job = job;
            UserRank = rank;
            StartDate = startDate;
        }
    }
}