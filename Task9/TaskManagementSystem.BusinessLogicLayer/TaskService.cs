using System.Text;
using TaskManagementSystem.DataAccessLayer;

namespace TaskManagementSystem.BusinessLogicLayer
{
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _taskManager;
        public TaskService(IRepositoryManager taskManager)
        {
            _taskManager = taskManager;
        }

        public async Task<DataAccessLayer.Task> CreateAsync(DataAccessLayer.Task task)
        {
            FillDescription(task);

            return await _taskManager.CreateTaskAsync(task);
        }

        public async Task<bool> DeleteAsync(int id) => await _taskManager.DeleteTaskAsync(id);

        public async Task<DataAccessLayer.Task?> GetTaskByIdAsync(int id) => await _taskManager.GetTaskByIdAsync(id);
        public async Task<IEnumerable<DataAccessLayer.Task>> GetAllTaskAsync() => await _taskManager.GetAllTasksAsync();
        public async Task<DataAccessLayer.Task> UpdateAsync(DataAccessLayer.Task task) => await _taskManager.UpdateTaskAsync(task);

        private void FillDescription(DataAccessLayer.Task task)
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

            if (string.IsNullOrEmpty(task.Description))
            {
                task.Description = description.ToString();
            }
            else
            {
                task.Description = $"{task.Description}\n{description}";
            }
        }
    }
}
