using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskCrud.Data;

namespace TaskCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(TaskDbContext context) : ControllerBase
    {
        
        private readonly TaskDbContext _context = context;
        
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetTasks() 
        {
            return Ok(await _context.Tasks.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if(task == null)
                return NotFound();

            return Ok(task);
        }
        
        [HttpPost]
        public async Task<ActionResult<TaskModel>> AddNewTask(TaskModel newTask) 
        { 
            if(newTask is null)
                return BadRequest();

            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTaskById), new { id = newTask.Id }, newTask);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskModel updateTask)
        {
            var task = await _context.Tasks.FindAsync(id);
            if(task == null)
                return NotFound();

            task.Name = updateTask.Name;
            task.Description = updateTask.Description;
            
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id) 
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
