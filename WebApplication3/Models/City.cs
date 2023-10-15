using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ZipCode { get; set; }

        [ForeignKey("Country")]
        public int? CountryId { get; set; }

        [AllowNull]
        [JsonIgnore]
        public Country Country { get; set; }

        //[AllowNull]
        //[JsonIgnore]
        //public ICollection<User> Users { get; set; }
    }
}
