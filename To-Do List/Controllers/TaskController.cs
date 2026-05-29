using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;

namespace To_Do_List.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        static private List<Models.Task> tasks = new List<Models.Task>()
        {
            new Models.Task
            {
                Id = 1,
                Date = "20-05-2026",
                Title = "Buy groceries",
                Description = "Buy some carrots, milk, and bread"
            },
            new Models.Task
            {
                Id = 2,
                Date = "25-05-2026",
                Title = "Clean the house",
                Description = "Clean the living room and kitchen"
            },
            new Models.Task
            {
                Id = 3,
                Date = "29-05-2026",
                Title = "Take out the trash",
                Description = "Take out the trash from the kitchen"
            },
        };

        [HttpGet]
        public ActionResult<List<Models.Task>> GetTasks()
        {
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Task> GetTaskById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<Models.Task> PostTask(Models.Task newTask)
        {
            if (newTask == null)
            {
                return BadRequest();
            }

            tasks.Add(newTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Models.Task updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            task.Id = updatedTask.Id;
            task.Date = updatedTask.Date;
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id) 
        { 
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            tasks.Remove(task);
            return NoContent();
        }
    }
}
