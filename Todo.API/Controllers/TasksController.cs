using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Todo.API.Models;

namespace Todo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        //POST: api/task
        [HttpPost]
        public async Task<ActionResult<Item>> Post(Item item)
        {
            return Ok();
        }

        //GET: api/task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            return Ok();
        }

        //GET: api/task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            return Ok();
        }

        //PUT: api/task/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> Put(int id, Item item)
        {
            return Ok();
        }

        //DELETE: api/task/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}   
