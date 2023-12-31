﻿using System.ComponentModel;
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

        public decimal? Price { get; set; }

        public int UnitsInStocks { get; set; }

        //  public List<byte[]> Images { get; set; }
        //[AllowNull]
       // public int? ImageId { get; set; }

        [AllowNull]
        [JsonIgnore]
        public List<Image>? Images { get; set;}

        [ForeignKey("ProductCategory")]
        public int? ProductCategoryId { get; set; }

        [ForeignKey("Statuses")]
  
        public int? StatusId { get; set; }

        [AllowNull]
        [JsonIgnore]
        public Status? Status { get; set; }

        [AllowNull]
        [JsonIgnore]
        public ProductCategory? Category { get; set; }
        //@TODO - dodaj sliku

        [AllowNull]
        [JsonIgnore]
        public List<Salesman> Salesmen { get; set; } = new();


        [JsonIgnore]
        [AllowNull]
        public List<Comment>? Comments { get; set; }


        //public Product(Product product)
        //{
        //    if (product != null)
        //    {
     
        //        Name = product.Name;
        //        Description = product.Description;
        //        Price = product.Price;
        //        UnitsInStocks = product.UnitsInStocks;
        //        ProductCategoryId = product.ProductCategoryId;
        //        Status = product.Status;
        //        StatusId = product.StatusId;
        //        Images = null;
        //    }
        //}

        //public Product(dtoProducts product)
        //{
        //    if (product != null)
        //    {
             
        //        Name = product.Name;
        //        Description = product.Description;
        //        Price = product.Price;
        //        UnitsInStocks = product.UnitsInStocks;
        //        ProductCategoryId = product.ProductCategoryId;
        //        Status = product.Status;
        //        StatusId = product.StatusId;
        //        Images = null;
                
        //    }
        //}
    }
}
