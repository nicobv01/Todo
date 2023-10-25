using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Todo.API.Models;
using Todo.API.Repositories.Task;

namespace Todo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        //POST: api/task
        [HttpPost]
        public async Task<ActionResult<Item>> Post(Item item)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var result = await _taskRepository.Insert(item, userId);

            if (!result)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        //GET: api/task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            return Ok();
        }

        //GET: api/task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(int id)
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
