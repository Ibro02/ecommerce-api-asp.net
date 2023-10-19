using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly DataContext _db;

        public StatusesController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<Status>> GetAll() 
        { 
        var listOfStatuses = _db.Statuses.ToList();
        if (listOfStatuses.Any())
            {
                return Ok(listOfStatuses);
            }

        return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Status> Get(int id)
        {
            var status = _db.Statuses.ToList().Where(x=>x.Id== id);
            if (status.Any())
            {
                return Ok(status);
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Status> Post(Status status)
        {
            try
            {
                _db.Statuses.Add(status);
                _db.SaveChanges();
            
                return Ok(status);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }


}
