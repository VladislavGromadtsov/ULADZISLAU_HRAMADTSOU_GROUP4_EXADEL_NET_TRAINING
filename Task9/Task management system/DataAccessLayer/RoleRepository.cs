using Task_management_system.Context;
using Task_management_system.Models;

namespace Task_management_system.DataAccessLayer
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext applicationContext) : base(applicationContext) 
        {
        }
        
    }
}
