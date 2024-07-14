using Domain.Domain.Country;
using System.ComponentModel.DataAnnotations;
using zooproject.Domain.Domain.Enums;
namespace zooproject.Domain.Domain.User
{
    public class Visitor
    {
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Adress { get; set; }
		[Required]
		public Country Country { get; set; }
		
		public Visitor() { }
        public Visitor(string firstname, string lastname, string email, string username, string password, string adress, Country country)
        {
			FirstName = firstname;
			LastName = lastname;
			Email = email;
			Username = username;
			Password = password;
			Adress = adress;
			Country = country;
        }

        public Visitor(int id,string firstname, string lastname, string email, string username, string password, string adress, Country country)
        {
			Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Username = username;
            Password = password;
			Adress = adress;
			Country = country;
        }
    }
}