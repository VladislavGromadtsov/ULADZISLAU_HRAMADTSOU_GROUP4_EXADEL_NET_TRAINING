
namespace TaskManagementSystem.DataAccessLayer
{
    public interface IUnitOfWork
    {
        ITaskRepository Tasks { get; set; }

        void Dispose();
        System.Threading.Tasks.Task SaveChangesAsync();
    }
}