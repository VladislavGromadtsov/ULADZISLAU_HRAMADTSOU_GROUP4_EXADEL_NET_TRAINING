using Microsoft.EntityFrameworkCore;

namespace TaskManagementSystem.DataAccessLayer
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationContext _context;
        public TaskRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Task?> GetByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Task>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Task> CreateAsync(Task task)
        {
            var taskEntity = await _context.Tasks.AddAsync(task);
            return taskEntity.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var taskEntity = await GetByIdAsync(id);

            if (taskEntity != null)
            {
                var taskEntityEntry = _context.Tasks.Remove(taskEntity);
                return taskEntityEntry != null;
            }

            return false;
        }

        public Task Update(Task task)
        {
            return _context.Tasks.Update(task).Entity;
        }
    }
}
