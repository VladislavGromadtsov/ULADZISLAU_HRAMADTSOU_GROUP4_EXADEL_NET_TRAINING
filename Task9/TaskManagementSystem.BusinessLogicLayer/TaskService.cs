using System.Text;
using TaskManagementSystem.DataAccessLayer;

namespace TaskManagementSystem.BusinessLogicLayer
{
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repository;
        public TaskService(IRepositoryManager repository)
        {
            this._repository = repository;
        }

        public IEnumerable<DataAccessLayer.Task> GetTasks()
        {
            return _repository.Task.GetAllTasks();
        }

        public DataAccessLayer.Task GetTaskById(int id)
        {
            return _repository.Task.GetTaskById(id);
        }

        public DataAccessLayer.Task Update(DataAccessLayer.Task task)
        {
            if (_repository.Task.GetTaskById(task.Id) == null)
            {
                return null;
            }

            _repository.Task.UpdateTask(task);
            _repository.Save();

            return task;
        }

        public bool Delete(int id)
        {
            var task = _repository.Task.GetTaskById(id);
            if (task == null) return false;

            _repository.Task.DeleteTask(task);
            _repository.Save();

            return true;
        }

        public DataAccessLayer.Task Create(DataAccessLayer.Task task)
        {
            FillDescription(task);

            _repository.Task.CreateTask(task);
            _repository.Save();

            return task;
        }

        private void FillDescription(DataAccessLayer.Task task)
        {
            var description = new StringBuilder();
            if (task.PerformerId != 0)
            {
                description.Append($"Creator: {task.Creator.FullName}. Created: {DateTime.Now}. Performer: {task.Performer.FullName}");
            }
            else
            {
                description.Append($"Creator: {task.Creator.FullName}. Created: {DateTime.Now}. No performer");
            }

            if (string.IsNullOrEmpty(task.Description))
            {
                task.Description = description.ToString();
            }
            else
            {
                task.Description = $"{task.Description}\n{description}";
            }
        }
    }
}
