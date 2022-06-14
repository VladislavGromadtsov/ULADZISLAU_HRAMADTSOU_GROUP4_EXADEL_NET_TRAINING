namespace TaskManagementSystem.DataAccessLayer
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAllTasks();
        Task GetTaskById(int taskId);
        void CreateTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(Task task);
    }
}