using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
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
        var listOfProducts = _db.Products.ToList();

        if (listOfProducts.Any())
            {
                return Ok(listOfProducts);
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
        public ActionResult<Product> Post(Product product)
        {
            try
            {
            _db.Products.Add(product);
            _db.SaveChanges();
            return Ok(product);
            }
            catch (Exception ex)
            {
             return BadRequest(ex.Message);
            }
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
