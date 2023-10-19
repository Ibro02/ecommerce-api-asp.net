using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly DataContext _db;

        public OrderController(DataContext db)
        {
            _db = db;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            if (_db.Orders.Any())
                return Ok(_db.Orders.ToList());

            return NoContent();
        }

        //// GET api/<OrderController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post([FromBody] Order value)
        {
            try
            {
                _db.Orders.Add(value);
                _db.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
