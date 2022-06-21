using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.DataAccessLayer
{
    [Table("Users")]
    public class UserEntity
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        public int RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }

        [Required, MaxLength(100), EmailAddress(ErrorMessage = "The Email is not valid")]
        public string Email { get; set; }

        [Required, MaxLength(20)]
        public string Password { get; set; }
        public virtual List<TaskEntity> TasksCreator { get; set; } = new List<TaskEntity> { };
        public virtual List<TaskEntity> TasksPerformer { get; set; } = new List<TaskEntity> { };
    }
}
