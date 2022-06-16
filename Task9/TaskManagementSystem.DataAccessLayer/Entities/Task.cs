using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagementSystem.DataAccessLayer.Enums;

namespace TaskManagementSystem.DataAccessLayer
{
    [Table("Tasks")]
    public class Task
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public Statuses Status { get; set; }

        [Required]
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
        
        public int PerformerId { get; set; }
        public virtual User Performer { get; set; }
    }
}
