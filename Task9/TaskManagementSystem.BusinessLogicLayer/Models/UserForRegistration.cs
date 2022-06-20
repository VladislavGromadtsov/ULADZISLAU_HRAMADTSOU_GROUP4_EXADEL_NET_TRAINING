using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.BusinessLogicLayer.Models
{
    public class UserForRegistration
    {
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public string Role { get; set; }

        [Required, MaxLength(100), EmailAddress(ErrorMessage = "The Email is not valid")]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        public string Password { get; set; }

    }
}
