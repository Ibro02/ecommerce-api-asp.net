using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using WebApplication3.Models;

namespace WebApplication3.Helpers.DTO
{
    public class dtoUser
    {

        public int Id { get; set; }

 
        public string? FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;
        public string? Username { get; set; } = string.Empty;
      
        public string? Password { get; set; } = string.Empty;


        public string? Phone { get; set; } = string.Empty;


        public string? Description { get; set; } = string.Empty;


        public int? CityId { get; set; }
    }
}
