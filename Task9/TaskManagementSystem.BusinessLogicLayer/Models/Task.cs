using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DataAccessLayer.Enums;

namespace TaskManagementSystem.BusinessLogicLayer.Models
{
    public class Task
    {
        [Required]
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
