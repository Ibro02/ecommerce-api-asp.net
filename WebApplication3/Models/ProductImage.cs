using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [AllowNull]
        public int ImageId { get; set; }
        [AllowNull]
        [JsonIgnore]
        public Product Product { get; set; }

        [AllowNull]
        [JsonIgnore]
        public Image Image { get; set; }

    }
}
