
namespace TaskManagementSystem.DataAccessLayer
{
    public interface IRepositoryManager
    {
        Task<Task> CreateTaskAsync(Task task);
        Task<bool> DeleteTaskAsync(int id);
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task<Task?> GetTaskByIdAsync(int id);
        Task<Task> UpdateTaskAsync(Task task);
    }
}