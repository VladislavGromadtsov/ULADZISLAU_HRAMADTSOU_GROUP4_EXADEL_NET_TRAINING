
using AutoMapper;
using TaskManagementSystem.DataAccessLayer;

namespace TaskManagementSystem.BusinessLogicLayer
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RepositoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Models.Task>> GetAllTasksAsync()
        {
            var entities = await _unitOfWork.Tasks.GetAllAsync();

            return _mapper.Map<IEnumerable<Models.Task>>(entities);
        }

        public async Task<Models.Task?> GetTaskByIdAsync(int id)
        {
            var entity = await _unitOfWork.Tasks.GetByIdAsync(id);

            return _mapper.Map<Models.Task>(entity);
        }

        public async Task<Models.Task> CreateTaskAsync(Models.Task task)
        {
            var entity = _mapper.Map<TaskEntity>(task);

            var result = await _unitOfWork.Tasks.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<Models.Task>(result);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var result = await _unitOfWork.Tasks.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<Models.Task> UpdateTaskAsync(Models.Task task)
        {
            var entityFromDb = await _unitOfWork.Tasks.GetByIdAsync(task.Id);

            entityFromDb.Status = task.Status;
            entityFromDb.Description = task.Description;
            entityFromDb.Name = task.Name;
            entityFromDb.PerformerId = task.PerformerId;
            entityFromDb.CreatorId = task.CreatorId;

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<Models.Task>(entityFromDb);
        }
    }
}