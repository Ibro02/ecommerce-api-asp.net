using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [JsonIgnore]
        public Role? Role { get; set; }

        [ForeignKey("Id")]
        public int? RoleId { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }

        [AllowNull]
        [JsonIgnore]
        public City? City { get; set; } 


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
          //  City = "Travnik";
  
   
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
        //    City =city;
 
    
        }
    }
}
