using zooproject.Domain.Domain.Enums;
namespace zooproject.Domain.Domain.User
{
    public class Visitor : User
    {
        public const Rank UserRank = Rank.Visitor;
        public Visitor() { }
        public Visitor(string firstname, string lastname, int phoneNumber, Gender usergender, int bSN, string email, string username, string password, DateTime birthdate, string specialication) : base(firstname, lastname, phoneNumber, usergender, bSN, email, username, password, birthdate, specialication)
        {

        }
    }
}