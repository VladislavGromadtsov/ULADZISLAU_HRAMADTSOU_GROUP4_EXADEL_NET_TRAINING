using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.BusinessLogicLayer;

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
        [Authorize(Roles = "TeamLead, Senior, Middle, Junior")]
        public async Task<IActionResult> GetTasks()
        {
            var result = await _taskService.GetAllTaskAsync();

            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "TeamLead, Senior, Middle, Junior")]
        public async Task<IActionResult> GetTask(int id)
        {
            var result = await _taskService.GetTaskByIdAsync(id);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "TeamLead, Senior, Middle")]
        public async Task<IActionResult> CreateTask(BusinessLogicLayer.Models.Task task)
        {
            if (task is null)
            {
                return BadRequest();
            }

            var result = await _taskService.CreateAsync(task);

            return Ok(result.Id);
        }

        [HttpPut]
        [Authorize(Roles = "TeamLead, Senior, Middle")]
        public async Task<IActionResult> UpdateTask(BusinessLogicLayer.Models.Task task)
        {
            if (task is null)
            {
                return BadRequest();
            }

            var result = await _taskService.UpdateAsync(task);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "TeamLead")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _taskService.DeleteAsync(id);

            return result ? Ok() : NotFound();
        }
    }
}