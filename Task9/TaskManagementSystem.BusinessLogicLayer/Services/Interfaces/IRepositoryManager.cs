
namespace TaskManagementSystem.BusinessLogicLayer
{
    public interface IRepositoryManager
    {
        Task<Models.Task> CreateTaskAsync(Models.Task task);
        Task<bool> DeleteTaskAsync(int id);
        Task<IEnumerable<Models.Task>> GetAllTasksAsync();
        Task<Models.Task?> GetTaskByIdAsync(int id);
        Task<Models.Task> UpdateTaskAsync(Models.Task task);
    }
}