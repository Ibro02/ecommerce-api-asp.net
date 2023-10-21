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
        public string? Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }

        [JsonIgnore]
        public Role? Role { get; set; }

        [ForeignKey("Id")]
        public int? RoleId { get; set; } = 2;

        [AllowNull]
        public string? Phone { get; set; } = string.Empty;

        [AllowNull]
        public string? Description { get; set; } = string.Empty;

        [ForeignKey("City")]
        public int? CityId { get; set; }

        [AllowNull]
        [JsonIgnore]
        public City? City { get; set; }

        //[AllowNull]
        //[JsonIgnore]
        //public List<Salesman> Salesmen { get; } = new();
        public User()
        {
            Id = 0;
            FirstName = "";  
            LastName = "";
            Email = "";
            Username = "";
            Password = "";
            Phone = "";
            Description = "";
     
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
