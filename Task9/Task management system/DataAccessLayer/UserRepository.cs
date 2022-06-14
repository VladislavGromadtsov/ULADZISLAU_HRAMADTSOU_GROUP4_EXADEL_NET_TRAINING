using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_management_system.Context;
using Task_management_system.Models;

namespace Task_management_system.DataAccessLayer
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext applicationContext) : base(applicationContext) 
        {
        }
    }
}
