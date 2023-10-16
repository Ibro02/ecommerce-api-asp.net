using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }
    }
}
