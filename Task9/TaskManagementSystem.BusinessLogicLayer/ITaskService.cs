
namespace TaskManagementSystem.BusinessLogicLayer
{
    public interface ITaskService
    {
        Task<DataAccessLayer.Task> CreateAsync(DataAccessLayer.Task task);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<DataAccessLayer.Task>> GetAllTaskAsync();
        Task<DataAccessLayer.Task?> GetTaskByIdAsync(int id);
        Task<DataAccessLayer.Task> UpdateAsync(DataAccessLayer.Task task);
    }
}