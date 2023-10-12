using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<User> Users { get; set; } = new List<User>();

        public Role()
        {
           
        }
        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
