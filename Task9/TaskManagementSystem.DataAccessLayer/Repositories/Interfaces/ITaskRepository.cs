
namespace TaskManagementSystem.DataAccessLayer
{
    public interface ITaskRepository
    {
        Task<Task> CreateAsync(Task task);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Task>> GetAllAsync();
        Task<Task?> GetByIdAsync(int id);
        Task Update(Task task);
    }
}