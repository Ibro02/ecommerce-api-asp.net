using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication3.Data;
using WebApplication3.Helpers.DTO;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly DataContext _db;

        public ProductsController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll() {
            var listOfImages = _db.Images;
            var listOfProducts = _db.ProductImages.Include(x => x.Product).Include(x => x.Image).Select(x => new dtoProductImage
            {
               ProductId = x.ProductId,
               Image = x.ImageId.ToString()
               
            }).ToList();
       

        if (listOfProducts.Any())
            {
                return Ok(listOfProducts.Select(x=> new
                {
                    Product = x.ProductId,
                    Images = listOfProducts.Where(y=>y.ProductId == x.ProductId).Select(z => new {Images = z.Image})
                }).DistinctBy(x=>x.Product));
            }

        return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<List<Product>> Get(int id)
        {
            var products = _db.Products.ToList().Where(x=>x.Id == id);

            if (products.Any())
            {
                return Ok(products);
            }

            return NoContent();
        }

        [HttpPost]
         public ActionResult<dtoProducts> Post(dtoProducts product) 
        {
            if (product != null) 
            try 
            {
                    var _product = new Product()
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        StatusId = product.StatusId,
                        UnitsInStocks = product.UnitsInStocks,
                        ProductCategoryId = product.ProductCategoryId,
                        Status = product.Status,
                        Images = new List<Image>() // Create an empty list to store images
                    };
                    _db.Products.Add(_product);
                    _db.SaveChanges(); // Save the product to generate its ID

                    foreach (var imageBytes in product.Images)
                    {
                        if (imageBytes != null)
                        {
                            var _image = new Image()
                            {
                                Images = Encoding.ASCII.GetBytes(imageBytes)
                            };
                            _db.Images.Add(_image);
                            _db.SaveChanges(); // Save the image to generate its ID

                            var productImage = new ProductImage()
                            {
                                ProductId = _product.Id,
                                ImageId = _image.Id
                            };
                            _db.ProductImages.Add(productImage);
                        }
                    }

                    _db.SaveChanges(); // Save the changes made to the product images
                    return Ok(_product); // Return the saved product
                }
            catch (Exception ex)
            {
             return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id) {

            try
            {
                var deletedProduct = _db.Products.Where(x => x.Id == id);
                _db.Products.Where(x => x.Id == id).ExecuteDelete();
                _db.SaveChanges();
                return Ok(deletedProduct);
            }
            catch(Exception ex) { 
            return BadRequest(ex.Message);
            }
        }


    }
}
