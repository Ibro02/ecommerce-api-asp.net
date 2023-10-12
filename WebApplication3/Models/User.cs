using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }    

        public string Password { get; set; }

        [JsonIgnore]
        public Role? Role { get; set; }

        [ForeignKey("Id")]
        public int? RoleId { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public string Country { get; set; }


        public User()
        {
            Id = 0;
            FirstName = "Ibrahim";  
            LastName = "hodzic";
            Email = "ibrahim@gmail.com";
            Username = "ibro";
            Password = "12345";
            Phone = "061-882-273";
            Description = "Student";
            City = "Travnik";
            Country = "Bosna i Hercegovina";
   
            //@TODO - make roles, country and city objects as it is drawn on diagram 
        }
        public User(int id,string firstName,string lastName,string email, string username, string password, string phone, string description, string city,string country)
        {
            Id = id;
            FirstName =firstName;
            LastName =lastName;
            Email =email;
            Username =username;
            Password =password;
            Phone =phone;
            Description =description;
            City =city;
            Country = country;
    
        }
    }
}
