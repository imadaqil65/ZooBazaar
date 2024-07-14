using Domain.Domain.Enums;
using System.Diagnostics.Contracts;
using zooproject.Domain.Domain.Enums;
namespace zooproject.Domain.Domain.User
{
    public class Employee : User
    {
        public JobType Job { get; set; }
        public Rank UserRank { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string LeavingReason { get; set; }
        public bool Fired { get; set; }
        public int ContractHours { get; set; }
        public WorkContract Workcontract { get; set; }

        public Employee()
        {

        }
        public Employee(JobType job, Rank rank, DateTime startDate, DateTime? endDate, string firstname, string lastname, int phoneNumber, Gender usergender, int bSN, string email, string username, string password, DateTime birthdate, string specialication, int contracthours, WorkContract contract) : base(firstname, lastname, phoneNumber, usergender, bSN, email, username, password, birthdate, specialication)
        {
            Job = job;
            UserRank = rank;
            StartDate = startDate;
            EndDate = endDate;
            ContractHours = contracthours;
            Workcontract = contract;
        }

        public Employee(JobType job, Rank rank, DateTime startDate, DateTime? endDate, int id, string firstname, string lastname, int phoneNumber, Gender usergender, int bSN, string email, string username, string password, DateTime birthdate, string specialication, int contracthours, WorkContract contract) : base(id, firstname, lastname, phoneNumber, usergender, bSN, email, username, password, birthdate, specialication)
        {
            Job = job;
            UserRank = rank;
            StartDate = startDate;
            EndDate = endDate;
            ContractHours = contracthours;
            Workcontract = contract;
        }

        public Employee(JobType job, Rank rank, DateTime? endDate, int id, string firstname, string lastname, int phoneNumber, Gender usergender, int bSN, string email, string username, string password, DateTime birthdate, string specialication, bool fired, string leavingReason) : base(id, firstname, lastname, phoneNumber, usergender, bSN, email, username, password, birthdate, specialication)
        {
            Job = job;
            UserRank = rank;
            EndDate = endDate;
            Fired = fired;
            LeavingReason = leavingReason;
        }

    }
}