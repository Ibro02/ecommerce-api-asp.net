using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
 
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly DataContext _db;

        public ProductCategoryController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<ProductCategory>> GetAll()
        {
           if (_db.Categories.Any())
                return Ok(_db.Categories.ToList());
            return NotFound("There is no categories in the list!");
        }

        [HttpPost]
        public ActionResult<ProductCategory> Post([FromBody] ProductCategory productCategory)
        {
            try
            {
                _db.Categories.Add(productCategory);
                _db.SaveChanges();
                return Ok(productCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
