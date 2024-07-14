using zooproject.Domain.Domain.Enums;
namespace zooproject.Domain.Domain.User
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public Gender UserGender { get; set; }
        public int BSN { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Specialication { get; set; }

        public User()
        {

        }
        public User(int id, string firstname, string lastname, int phoneNumber, Gender usergender, int bSN, string email, string username, string password, DateTime birthdate, string specialication)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = phoneNumber;
            UserGender = usergender;
            BSN = bSN;
            Email = email;
            Username = username;
            Password = password;
            BirthDate = birthdate;
            Specialication = specialication;
        }

        public User(string firstname, string lastname, int phoneNumber, Gender usergender, int bSN, string email, string username, string password, DateTime birthdate, string specialication)
        {
            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = phoneNumber;
            UserGender = usergender;
            BSN = bSN;
            Email = email;
            Username = username;
            Password = password;
            BirthDate = birthdate;
            Specialication = specialication;
        }
        public int GetUserAge()
        {
            return Calculator.ToAge(this.BirthDate);
        }
    }
}