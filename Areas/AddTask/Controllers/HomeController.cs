using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Areas.AddTask.Models;

namespace ToDoList.Areas.AddTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly TempxContext tempxContext;
        public HomeController(TempxContext _tempx)
        {
            tempxContext = _tempx;
        }

        [HttpPost("addtask")]

        public async Task<IActionResult> addTask([FromBody] Todoapp todoapp)
        {
            if(todoapp == null)
                return NotFound(new {Message = "Empty title submitted"});

            await tempxContext.Todoapps.AddAsync(todoapp);
            await tempxContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Task Added Successfully!!"
            });
        }

        [HttpGet("gettask")]
        public async Task<IActionResult> getTask()
        {
          var task = await tempxContext.Todoapps.ToListAsync();
            return Ok(task);
        }

        [HttpPut("updatetask/{id:int}")]
        public async Task<IActionResult> updateTask([FromBody] Todoapp todoapp, int id)
        {
            if (todoapp == null)
                return BadRequest(new { Message = "Bad Request" });

            var taskId = await tempxContext.Todoapps.FindAsync(id);

            if(taskId==null)
            {
                return NotFound();
            }

            taskId.Title = todoapp.Title;
            taskId.Description = todoapp.Description;

            await tempxContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Update Done!"
            });
        }

        [HttpDelete("deletetask/{id:int}")]

        public async Task<IActionResult> deleteTask(int id)
        {
            var taskId = await tempxContext.Todoapps.FindAsync(id);
            if(taskId==null)
                return NotFound();

            tempxContext.Remove(taskId);
            tempxContext.SaveChanges();

            return Ok(new
            {
                Message = "Delete Done!"
            });
        }

    }
}
