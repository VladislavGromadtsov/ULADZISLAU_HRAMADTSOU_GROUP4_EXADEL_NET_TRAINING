namespace Task_management_system.DataAccessLayer
{
    public interface ITaskRepository
    {
        IEnumerable<Models.Task> GetAllTasks();
        Models.Task GetTaskById(int taskId);
        void CreateTask(Models.Task task);
        void UpdateTask(Models.Task task);
        void DeleteTask(Models.Task task);
    }
}