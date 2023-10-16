using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class Salesman
    {



        [Required]
        [ForeignKey(nameof(Models.User))]
        public int? SalesmanId { get; set; }

        [ForeignKey(nameof(Models.Product))]
        [Required]
        public int? ProductId { get; set; }


        [AllowNull]
        [JsonIgnore]
        public User User { get; set; }

        [AllowNull]
        [JsonIgnore]
        public Product Product { get; set; }



    }
}
