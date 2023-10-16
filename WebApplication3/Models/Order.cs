using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Products")]
        public int? ProductId { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int? CustomerId { get; set; }


        public decimal? Rating { get; set; }
        
        public string OrderDate = DateTime.Now.ToString("O");

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal SubTotalPrice { get; set; }

        public decimal Discount { get; set; }



        [AllowNull]
        [JsonIgnore]
        public Product Product { get; set; }


        [AllowNull]
        [JsonIgnore]
        public User Customer { get; set; }

    }
}
