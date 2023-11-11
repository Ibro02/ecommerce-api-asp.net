using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication3.Helpers.DTO
{
    public class dtoProductImage
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public List<int> ImageIds { get; set; }

        public int ProductId { get; set; }
        
    }
}
