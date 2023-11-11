using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class dtoProducts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }

        public decimal? Price { get; set; }

        public int UnitsInStocks { get; set; } = 1;

        public string[]? Images { get; set; }

        [ForeignKey("ProductCategory")]
        [AllowNull]
        public int? ProductCategoryId { get; set; }

        [ForeignKey("Statuses")]

        public int? StatusId { get; set; }

        [AllowNull]
        [JsonIgnore]
        public Status? Status { get; set; }

        [AllowNull]
        [JsonIgnore]
        public ProductCategory? Category { get; set; }

    }
}
