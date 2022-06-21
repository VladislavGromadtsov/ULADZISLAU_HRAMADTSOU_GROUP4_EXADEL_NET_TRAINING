
namespace TaskManagementSystem.DataAccessLayer
{
    public interface ITaskRepository
    {
        Task<TaskEntity> CreateAsync(TaskEntity task);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TaskEntity>> GetAllAsync();
        Task<TaskEntity?> GetByIdAsync(int id);
        TaskEntity Update(TaskEntity task);
    }
}