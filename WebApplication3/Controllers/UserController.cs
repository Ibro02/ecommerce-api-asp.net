using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication3.Data;
using WebApplication3.Helpers.DTO;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly DataContext _db;
 
        public UserController(DataContext db)
        {
            _db = db;
           
        }
        [HttpGet]
        public ActionResult GetAllUsernames() { 
        var listOfUsernames = new List<string>();
        foreach (var user in _db.Users)
            {
                listOfUsernames.Add(user.Username);
            }
            return Ok(listOfUsernames);
        }

        // GET: api/<UserController>
        [Authorize]
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
                    return NotFound("There are no users in DataBase!");
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }

      
        }


        // GET api/Users
        [Authorize]
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
        public ActionResult Post([FromBody] User value)
        {
            try
            {
            _db.Add(value);
            _db.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/User/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<User> Put([FromBody] dtoUser value, int id)
        {


            var userList = _db.Users.ToList().Where(x => x.Id == id).FirstOrDefault<User>();
            if (userList != null)
            {
                Console.WriteLine(value);
                if (!value.FirstName.IsNullOrEmpty()) userList.FirstName = value?.FirstName;
                else userList.FirstName += value.FirstName;
                if (!value.LastName.IsNullOrEmpty()) userList.LastName = value?.LastName;
                else userList.LastName += value.LastName;
                if (!value.Email.IsNullOrEmpty()) userList.Email = value?.Email;
                else userList.Email += value.Email;
                if (!value.Password.IsNullOrEmpty()) userList.Password = value?.Password;
                else userList.Password += value.Password;       
                if (!value.Description.IsNullOrEmpty()) userList.Description = value?.Description;
                else userList.Description += value.Description;
                if (!value.Phone.IsNullOrEmpty()) userList.Phone = value?.Phone;
                else userList.Phone += value.Phone;
                if (value.CityId!=null) userList.CityId = value?.CityId;
                if (!value.Username.IsNullOrEmpty()) userList.Username = value?.Username;
                else userList.Username += value.Username;
            _db.SaveChanges();

                return Ok(userList);
            }

            return BadRequest("Something went wrong");


        }

        // DELETE api/<UserController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Users.Where(x=>x.Id == id).ExecuteDelete();
            _db.SaveChanges();
        }
    }
}
    
