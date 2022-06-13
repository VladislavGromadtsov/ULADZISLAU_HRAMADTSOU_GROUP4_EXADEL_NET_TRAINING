using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_management_system.Context;
using Task_management_system.Models;
using Task_management_system.Models.Validators;

namespace Task_management_system.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ApplicationContext _context;

        public TaskController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks()
        {
            return await _context.Tasks.Include(t => t.Creator).Include(t => t.Performer).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTask(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Creator)
                .Include(t => t.Performer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return new ObjectResult(task);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Task>> CreateTask(Models.Task task)
        {
            if (task is null)
            {
                return BadRequest();
            }

            var validator = new TaskValidation();
            var validationResult = validator.Validate(task);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine($"Property {error.PropertyName} failed validation. Error {error.ErrorCode} {error.ErrorMessage}");
                }

                return BadRequest();
            }
            else
            {
                await _context.AddAsync(task);
                await _context.SaveChangesAsync();

                return Ok(task);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Models.Task>> UpdateTask(Models.Task task)
        {
            if (task is null)
            {
                return BadRequest();
            }

            if (!await _context.Tasks.AnyAsync(t => t.Id == task.Id))
            {
                return NotFound();
            }

            var validator = new TaskValidation();
            var validationResult = validator.Validate(task);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine($"Property {error.PropertyName} failed validation. Error {error.ErrorCode} {error.ErrorMessage}");
                }

                return BadRequest();
            }
            else
            {
                _context.Update(task);
                await _context.SaveChangesAsync();
                return Ok(task);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Task>> DeleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task is null)
            {
                return NotFound();
            }

            _context.Remove(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }
    }
}