
namespace TaskManagementSystem.BusinessLogicLayer
{
    public interface ITaskService
    {
        Task<Models.Task> CreateAsync(Models.Task task);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Models.Task>> GetAllTaskAsync();
        Task<Models.Task?> GetTaskByIdAsync(int id);
        Task<Models.Task> UpdateAsync(Models.Task task);
    }
}