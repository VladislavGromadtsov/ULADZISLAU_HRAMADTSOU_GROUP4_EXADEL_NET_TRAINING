namespace Task_management_system.DataAccessLayer
{
    public interface ITaskRepository
    {
        IEnumerable<Models.Task> GetAllTasks(bool trackChanges);
        Models.Task GetTaskById(int taskId, bool trackChanges);
        void CreateTask(Models.Task task);
        void UpdateTask(Models.Task task);
        void DeleteTask(Models.Task task);
    }
}