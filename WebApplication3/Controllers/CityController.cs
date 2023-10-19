using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext _db;

        public CityController(DataContext db)
        {
            _db = db;
        }

        //GET ALL /api/City
        [HttpGet()]
        public ActionResult<List<City>> GetAll()
        {
            var listOfCities = _db.Cities.ToList();
            if (listOfCities.Any()) 
            return Ok(listOfCities);

            return NotFound("There is no cities in database!");
        }

        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            var listOfCities = _db.Cities.ToList();
            if (listOfCities.Any())
                return Ok(listOfCities[id]);

            return NotFound("There is no cities in database!");
        }

        [HttpPost]
        public ActionResult Post([FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest("Something went wrong! Please, try again!");
            }
            try
            {
                _db.Cities.Add(city);
                _db.SaveChanges();
            return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deletedElement = _db.Cities.Where(x => x.Id == id);
            _db.Cities.Where(x => x.Id == id).ExecuteDelete();
            _db.SaveChanges();
            if (deletedElement != null)
            return Ok(deletedElement);

            return NotFound("There is no city with that id!");
        }

    }
}
