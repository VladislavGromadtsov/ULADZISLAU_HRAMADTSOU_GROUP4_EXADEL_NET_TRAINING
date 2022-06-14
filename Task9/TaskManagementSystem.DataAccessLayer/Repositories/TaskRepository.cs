

namespace TaskManagementSystem.DataAccessLayer
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public void CreateTask(Task task) => Create(task);

        public void DeleteTask(Task task) => Delete(task);

        public IEnumerable<Task> GetAllTasks() => 
            FindAll().OrderBy(x => x.Id).ToList();

        public Task GetTaskById(int taskId) =>
            FindByCondition(t => t.Id.Equals(taskId))
            .SingleOrDefault();

        public void UpdateTask(Task task) => Update(task);
    }
}
