using Task_management_system.Context;

namespace Task_management_system.DataAccessLayer
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationContext _context;
        private ITaskRepository _taskRepository;

        private IUserRepository _userRepository;

        private IRoleRepository _roleRepository;

        public RepositoryManager(ApplicationContext context)
        {
            this._context = context;
        }

        public ITaskRepository Task
        {
            get
            {
                if (_taskRepository is null)
                {
                    _taskRepository = new TaskRepository(_context);
                }

                return _taskRepository;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_roleRepository is null)
                {
                    _roleRepository = new RoleRepository(_context);
                }

                return _roleRepository;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_userRepository is null)
                {
                    _userRepository = new UserRepository(_context);
                }

                return _userRepository;
            }
        }

        public void Save() => _context.SaveChanges();
    }
}