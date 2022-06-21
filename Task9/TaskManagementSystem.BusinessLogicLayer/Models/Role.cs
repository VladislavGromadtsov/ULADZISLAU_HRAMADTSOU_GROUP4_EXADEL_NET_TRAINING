using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.BusinessLogicLayer.Models
{
    public class Role
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
