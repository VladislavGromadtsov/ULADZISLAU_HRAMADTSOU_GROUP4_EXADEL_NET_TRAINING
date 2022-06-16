using Microsoft.AspNetCore.Mvc;
using System.Text;
using TaskManagementSystem.BusinessLogicLayer;
using TaskManagementSystem.DataAccessLayer;

namespace TaskManagementSystem.PresentationLayer
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var result = await _taskService.GetAllTaskAsync();

            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var result = await _taskService.GetTaskByIdAsync(id);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(DataAccessLayer.Task task)
        {
            if (task is null)
            {
                return BadRequest();
            }

            var result = await _taskService.CreateAsync(task);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(DataAccessLayer.Task task)
        {
            if (task is null)
            {
                return BadRequest();
            }

            var result = await _taskService.UpdateAsync(task);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _taskService.DeleteAsync(id);

            return result ? Ok() : NotFound();
        }
    }
}