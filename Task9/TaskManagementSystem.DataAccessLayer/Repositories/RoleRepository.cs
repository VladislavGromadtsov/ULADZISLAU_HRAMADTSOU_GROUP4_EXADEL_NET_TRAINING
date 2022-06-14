

namespace TaskManagementSystem.DataAccessLayer
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext applicationContext) : base(applicationContext) 
        {
        }
        
    }
}
