using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
