namespace Task_management_system.DataAccessLayer
{
    public interface IRepositoryManager
    {
        ITaskRepository Task { get; }
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        void Save();
    }
}
