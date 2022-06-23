using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.DataAccessLayer
{
    public class RoleEntity : IdentityRole<int>
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public virtual List<UserEntity> Users { get; set; } = new List<UserEntity>();
    }
}
