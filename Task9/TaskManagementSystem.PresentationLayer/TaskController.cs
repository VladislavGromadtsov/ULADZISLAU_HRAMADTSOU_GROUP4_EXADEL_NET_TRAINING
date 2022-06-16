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
            this._taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _taskService.GetTasks();
            if (tasks is null)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = _taskService.GetTaskById(id);

            if (task is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(task);
            }
        }

        [HttpPost]
        public IActionResult CreateTask(DataAccessLayer.Task task)
        {
            if (task is null)
            {
                return BadRequest();
            }

            _taskService.Create(task);

            return Ok(task);
        }

        [HttpPut]
        public IActionResult UpdateTask(DataAccessLayer.Task task)
        {
            if (task is null)
            {
                return BadRequest();
            }

            var taskUp = _taskService.Update(task);

            if (taskUp == null)
            {
                return NotFound();
            }
            
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var checkDelete = _taskService.Delete(id);

            if (!checkDelete)
            {
                return NotFound();
            }

            return NoContent();
        }

        
    }
}