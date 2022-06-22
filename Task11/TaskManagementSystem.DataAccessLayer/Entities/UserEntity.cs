using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.DataAccessLayer
{
    public class UserEntity : IdentityUser<int>
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required, MaxLength(50)]
        [Column("FullName")]
        public override string UserName { get; set; }

        [Required, MaxLength(100), EmailAddress(ErrorMessage = "The Email is not valid")]
        public override string Email { get; set; }

        [Required, MaxLength(20)]
        public string Password { get; set; }
        public virtual List<TaskEntity> TasksCreator { get; set; } = new List<TaskEntity> { };
        public virtual List<TaskEntity> TasksPerformer { get; set; } = new List<TaskEntity> { };
    }
}
