using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.BusinessLogicLayer.Models;

namespace TaskManagementSystem.BusinessLogicLayer.Authentification
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthentification userForAuth);
        Task<string> CreateToken();
    }
}
