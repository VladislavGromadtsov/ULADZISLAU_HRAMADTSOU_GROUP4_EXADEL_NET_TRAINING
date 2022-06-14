namespace TaskManagementSystem.DataAccessLayer
{
    public interface IRepositoryManager
    {
        ITaskRepository Task { get; }
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        void Save();
    }
}
