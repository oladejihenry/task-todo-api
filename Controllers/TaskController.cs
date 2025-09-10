using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        
        static private List<Task> tasks = new List<Task>
        {
            new Task
            {
                Id = 1,
                Name = "Test",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Task
            {
                Id = 2,
                Name = "Test",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        };

        [HttpGet]
        public ActionResult<List<Task>> GetTasks() {
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id );
            if(task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public ActionResult<Task> AddNewTask(Task newTask) 
        { 
            if(newTask == null)
                return BadRequest();

            newTask.Id = tasks.Max(t => t.Id) + 1;
            tasks.Add(newTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Task updateTask)
        {
            var task = tasks.FirstOrDefault(t =>t.Id == id);
            if(task == null)
                return NotFound();

            task.Name = updateTask.Name;
            task.Description = updateTask.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id) 
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            tasks.Remove(task);

            return NoContent();
        }
    }
}
