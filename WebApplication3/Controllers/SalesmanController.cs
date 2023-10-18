using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesmanController : ControllerBase
    {

        private readonly DataContext _db;

        public SalesmanController(DataContext db)
        {
            _db = db;
        }


        [HttpGet]
        public ActionResult<List<Salesman>> GetAll() 
        {
        if (_db.Salesmen.Any())
            {
                return Ok(_db.Salesmen.ToList());
            }

        return NotFound();
        }


        [HttpPost]
        public ActionResult<Salesman> Post([FromBody] Salesman salesman)
        {
           try
            {
                _db.Salesmen.Add(salesman);
                _db.SaveChanges();
                return Ok(salesman);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
