using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly DataContext _db;
 
        public UserController(DataContext db)
        {
            _db = db;
           
        }

        // GET: api/<UserController>
        [HttpGet("/api/[controller]")]
        public ActionResult<List<User>> GetAll()
        {
            try
            {
                List<User> users = _db.Users.ToList();
                if (users != null && users.Count>0)
                {
                    return Ok(users);
                }
                    return Ok("There are no users in DataBase!");
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }

      
        }

        // GET api/Users
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
            return _db.Users.ToList().Find(u => u.Id == id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/Users
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _db.Add(value);
            _db.SaveChanges();
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var userList = _db.Users.ToList().Where(x=>x.Id == id);
            if (userList != null) {
                var user = userList.First();
                user.CityId = int.Parse(value);
               _db.Users.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            

        _db.SaveChanges();
            
          
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Users.Where(x=>x.Id == id).ExecuteDelete();
            _db.SaveChanges();
        }
    }
}
    
