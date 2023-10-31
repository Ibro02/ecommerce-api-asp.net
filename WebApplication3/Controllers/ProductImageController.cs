using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication3.Data;
using WebApplication3.Helpers.DTO;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        readonly DataContext _db;

        public ProductImageController(DataContext db) {  _db = db; }

        [HttpGet]
        public ActionResult<List<Image>> GetAllImages() { 
        
            if (!_db.Images.IsNullOrEmpty())
                return Ok(_db.Images.ToList());
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<ProductImage>> GetAllProductsImages()
        {

            if (!_db.ProductImages.IsNullOrEmpty())
                return Ok(_db.ProductImages.ToList());
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<List<ProductImage>> GetProductImages(int id)
        {
            var productImages = _db.ProductImages.Where(x=>x.ProductId == id).ToList(); 
            if (productImages.Any())
            return Ok(productImages);

            return NoContent();

        }

        [HttpPost]
        public ActionResult AddNewProductImage(dtoProductImage image)
        {
            if (image.Image == null)
                return BadRequest("First select image!");
            if (_db.Products.Where(x => x.Id == image.ProductId).ToList().IsNullOrEmpty())
            {
                return BadRequest("You tried to add image to non-existing product!");
            }

            var newImage = new Image() { Images = Encoding.ASCII.GetBytes(image.Image) } ;
            _db.Images.Add(newImage);
          
           

            var newProductImage = new ProductImage()
            {Id=0,Image = newImage, ImageId = newImage.Id,ProductId = image.ProductId };
            _db.ProductImages.Add(newProductImage);

            _db.SaveChanges();

            return Ok("Success!");
        }

        [HttpGet]
        public ActionResult GetStrings(int id)
        {
            try
            {

            return Ok(Encoding.ASCII.GetString(_db.Images.Select(x => x.Images).ToList()[id]));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
