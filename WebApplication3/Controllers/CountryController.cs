using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly DataContext _db;

        public CountryController(DataContext db)
        {
            _db = db;
        }

        //GET ALL /api/Country
        [HttpGet]
        public ActionResult<List<Country>> Get()
        {
            var listOfCountries = _db.Countries.ToList();
            if (listOfCountries.Any())
            return Ok(listOfCountries);
            
        return NotFound("There is no countries in database!"); 
        }
        //GET BY ID /api/Country
        [HttpGet("{id}")]
        public ActionResult<Country> Get(int id) 
        {
         var country = _db.Countries.ToList();
            if (country != null)
            {
            return Ok(country[id]);
            }

            return NotFound("There is no city in database!");
        }
        [HttpPost]        
        public ActionResult<Country> Post(Country country)
        {
            try
            {
        _db.Countries.Add(country);
        _db.SaveChanges();

                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
