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
    public class RoleController : ControllerBase
    {

        private readonly DataContext _db;

        public RoleController(DataContext db)
        {
            _db = db;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Role>> GetAll()
        {
         try
            {
                List<Role> roles = _db.Roles.ToList(); 
                if (roles.Count > 0)
                { 
                return Ok(roles);
                }
                return BadRequest("There is no roles yet!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var role = _db.Roles.SingleOrDefault(x => x.Id == id);
            try
            {
            return Ok(role);
            }
            catch (Exception ex) { 
            return BadRequest(ex.Message);
            }
        }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] dtoRoles value)
        //{
        //    if (value != null)
        //    {
        //        var _value = new Role(value.Id,value.Name);
        //        _db.Roles.Add(_value);
        //        _db.SaveChanges();
        //    }
            
   

        //}

       //// PUT api/<ValuesController>/5
       //[HttpPut("{id}")]
       //public void Put(int id, [FromBody] string value)
       //{
       //}

       //// DELETE api/<ValuesController>/5
       //[HttpDelete("{id}")]
       //public void Delete(int id)
       //{
          
       //     _db.Roles.Where(x => x.Id == id).ExecuteDelete();
       //     _db.SaveChanges();
          
       // }
    }
}
