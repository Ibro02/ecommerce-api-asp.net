using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication3.Data;
using WebApplication3.Helpers.DTO;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly DataContext _db;

        public ImageController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<Image>> GetImages()
        {
            try
            {
                var images = _db.Images.ToList();
                return Ok(images);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //    [HttpPost]

        //    public ActionResult PostImages([FromBody] List<dtoProductImage> images) {
        //        try
        //        {
        //        if (!images.IsNullOrEmpty())
        //        foreach (var image in images)
        //        {
        //            if (_db.Products.Where(x => x.Id == image.ProductId).ToList().IsNullOrEmpty())
        //                return BadRequest("You tried to add image to non-existing product!");

        //            var newImage = new Image() { Images = Encoding.ASCII.GetBytes(image.Image), ProductId = _db.Products.ToList()[_db.Products.Count()-1].Id };
        //            _db.Images.Add(newImage); 

        //            _db.SaveChanges();

        //        }
        //        return Ok(images);
        //        } 
        //        catch(Exception ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }
        //}
    }

}