using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace WebApplication3.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public string CommentDate = DateTime.Now.ToString("O");
        [AllowNull]
        [JsonIgnore]
        public Product? Product { get; set; }


        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }

        [AllowNull]
        [JsonIgnore]
        public User? User { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; } 



    }

}
