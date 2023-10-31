using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public byte[] Images { get; set; }

        public int ProductImageId { get; set; }

        [AllowNull]
        [JsonIgnore]
        public List<ProductImage> ProductImage { get; set; }
       
    }
}
