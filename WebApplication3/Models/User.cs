using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public User()
        {
            Id = 1;
            FirstName = "Ibrahim";  
            LastName = string.Empty;
        }
        public User(int id,string firstName,string lastName)
        {
            Id =id;
            FirstName =firstName;
            LastName =lastName;
        }
    }
}
