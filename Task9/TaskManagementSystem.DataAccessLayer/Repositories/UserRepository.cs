

namespace TaskManagementSystem.DataAccessLayer
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext applicationContext) : base(applicationContext) 
        {
        }
    }
}
