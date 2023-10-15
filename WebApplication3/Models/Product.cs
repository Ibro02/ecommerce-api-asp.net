using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }

        //public string Category { get; set; } -> I should add this 


        public decimal? Price { get; set; }

        public int UnitsInStocks { get; set; }

        [ForeignKey("Salesman")]
        public int? SalesmanId { get; set; }

        [JsonIgnore]
        public Salesman Salesman { get; set; }  

        [ForeignKey("Statuses")]
        public int? StatusID { get; set; }

        [JsonIgnore]
        [AllowNull]
        public Status Status { get; set; }

    }
}
