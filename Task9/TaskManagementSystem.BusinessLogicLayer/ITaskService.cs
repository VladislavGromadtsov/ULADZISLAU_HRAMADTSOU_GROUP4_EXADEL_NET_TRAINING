
namespace TaskManagementSystem.BusinessLogicLayer
{
    public interface ITaskService
    {
        DataAccessLayer.Task Create(DataAccessLayer.Task task);
        bool Delete(int id);
        DataAccessLayer.Task GetTaskById(int id);
        IEnumerable<DataAccessLayer.Task> GetTasks();
        DataAccessLayer.Task Update(DataAccessLayer.Task task);
    }
}