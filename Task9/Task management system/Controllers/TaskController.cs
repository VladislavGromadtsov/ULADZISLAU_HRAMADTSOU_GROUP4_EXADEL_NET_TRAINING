using Microsoft.AspNetCore.Mvc;
using System.Text;
using Task_management_system.DataAccessLayer;

namespace Task_management_system.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private readonly IRepositoryManager _repository;

        public TaskController(IRepositoryManager repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            //try
            //{
                var tasks = _repository.Task.GetAllTasks();

                return Ok(tasks);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, "Internal server error");
            //}
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = _repository.Task.GetTaskById(id);

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
        public IActionResult CreateTask(Models.Task task)
        {
            if (task is null)
            {
                return BadRequest();
            }

            FillDescription(task);

            _repository.Task.CreateTask(task);
            _repository.Save();

            return Ok(task);
            //var validator = new TaskValidation();
            //var validationResult = validator.Validate(task);
            //if (!validationResult.IsValid)
            //{
            //    foreach (var error in validationResult.Errors)
            //    {
            //        Console.WriteLine($"Property {error.PropertyName} failed validation. Error {error.ErrorCode} {error.ErrorMessage}");
            //    }

            //    return BadRequest();
            //}
            //else
            //{
            //    await _context.AddAsync(task);
            //    await _context.SaveChangesAsync();

            //    return Ok(task);
            //}
        }

        [HttpPut]
        public IActionResult UpdateTask(Models.Task task)
        {
            if (task is null)
            {
                return BadRequest();
            }

            if (_repository.Task.GetTaskById(task.Id) == null)
            {
                return NotFound();
            }

            _repository.Task.UpdateTask(task);
            _repository.Save();
            
            return Ok(task);
            //var validator = new TaskValidation();
            //var validationResult = validator.Validate(task);
            //if (!validationResult.IsValid)
            //{
            //    foreach (var error in validationResult.Errors)
            //    {
            //        Console.WriteLine($"Property {error.PropertyName} failed validation. Error {error.ErrorCode} {error.ErrorMessage}");
            //    }

            //    return BadRequest();
            //}
            //else
            //{
            //    _context.Update(task);
            //    await _context.SaveChangesAsync();
            //    return Ok(task);
            //}
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _repository.Task.GetTaskById(id);
            if (task is null)
            {
                return NotFound();
            }
            
            _repository.Task.DeleteTask(task);
            _repository.Save();

            return NoContent();

            //var validator = new TaskValidation();
            //var validationResult = validator.Validate(task.Result);
            //if (!validationResult.IsValid)
            //{
            //    foreach (var error in validationResult.Errors)
            //    {
            //        Console.WriteLine($"Property {error.PropertyName} failed validation. Error {error.ErrorCode} {error.ErrorMessage}");
            //    }

            //    return BadRequest();
            //}
            //else
            //{
            //    _context.Remove(task);
            //    await _context.SaveChangesAsync();
            //    return Ok(task);
            //}
        }

        private void FillDescription(Models.Task task)
        {
            var description = new StringBuilder();
            if (task.PerformerId != 0)
            {
                description.Append($"Creator: {task.Creator.FullName}. Created: {DateTime.Now}. Performer: {task.Performer.FullName}");
            }
            else
            {
                description.Append($"Creator: {task.Creator.FullName}. Created: {DateTime.Now}. No performer");
            }

            task.Description = $"{task.Description}{description}";
        }
    }
}