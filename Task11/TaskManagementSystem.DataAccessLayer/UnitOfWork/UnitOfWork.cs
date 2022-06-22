
namespace TaskManagementSystem.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public ITaskRepository Tasks { get; set; }
        public UnitOfWork(ApplicationContext context, ITaskRepository taskRepository)
        {
            _context = context;
            Tasks = taskRepository;
        }

        public System.Threading.Tasks.Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
