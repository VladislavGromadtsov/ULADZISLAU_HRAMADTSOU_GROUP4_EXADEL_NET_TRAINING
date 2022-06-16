

namespace TaskManagementSystem.DataAccessLayer
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Task>> GetAllTasksAsync() => await _unitOfWork.Tasks.GetAllAsync();

        public async Task<Task?> GetTaskByIdAsync(int id) => await _unitOfWork.Tasks.GetByIdAsync(id);

        public async Task<Task> CreateTaskAsync(Task task) => await _unitOfWork.Tasks.CreateAsync(task);

        public async Task<bool> DeleteTaskAsync(int id) => await _unitOfWork.Tasks.DeleteAsync(id);

        public async Task<Task> UpdateTaskAsync(Task task)
        {
            var entityFromDb = await _unitOfWork.Tasks.GetByIdAsync(task.Id);

            entityFromDb.Status = task.Status;
            entityFromDb.Description = task.Description;
            entityFromDb.Name = task.Name;
            entityFromDb.Performer = task.Performer;
            entityFromDb.PerformerId = task.PerformerId;
            entityFromDb.CreatorId = task.CreatorId;
            entityFromDb.Creator = task.Creator;

            await _unitOfWork.SaveChangesAsync();

            return entityFromDb;
        }
    }
}