using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.DataAccessLayer.Enums;

namespace TaskManagementSystem.DataAccessLayer
{
    public class ApplicationContext : IdentityDbContext<UserEntity, RoleEntity, int>
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(b =>
            {
                b.ToTable("Users");
            });

            modelBuilder.Entity<RoleEntity>(b =>
            {
                b.ToTable("Roles");
            });

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Creator)
                .WithMany(u => u.TasksCreator)
                .HasForeignKey(t => t.CreatorId)
                .IsRequired(true);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Performer)
                .WithMany(u => u.TasksPerformer)
                .HasForeignKey(t => t.PerformerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity[]
                {
                    new RoleEntity { Id = 1, Name = "TeamLead", NormalizedName = "TEAMLEAD" },
                    new RoleEntity { Id = 2, Name ="Senior", NormalizedName = "SENIOR"},
                    new RoleEntity { Id = 3, Name ="Middle", NormalizedName = "MIDDLE"},
                    new RoleEntity { Id = 4, Name ="Junior", NormalizedName = "JUNIOR"}
                });

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity[]
                {
                    new UserEntity { Id = 1, UserName ="Ivan Ivanov", Email ="ivan@gmail.com", Password="ivanivan"},
                    new UserEntity { Id = 2, UserName ="Vasya Vasiliev", Email="vasya@gmail.com", Password="123"},
                    new UserEntity { Id = 3, UserName ="Petya Petrov", Email="petya@gmail.com", Password ="qwerty"},
                    new UserEntity { Id = 4, UserName ="Katya Vasilenko", Email="Katya@gmail.com", Password ="qwerty123"},
                    new UserEntity { Id = 5, UserName ="Vika Viktorieva", Email="vika@gmail.com", Password ="qwerty111"},
                });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>[]
                {
                    new IdentityUserRole<int> {RoleId = 2, UserId = 1},
                    new IdentityUserRole<int> {RoleId = 3, UserId = 2},
                    new IdentityUserRole<int> {RoleId = 4, UserId = 3},
                    new IdentityUserRole<int> {RoleId = 1, UserId = 4},
                    new IdentityUserRole<int> {RoleId = 2, UserId = 5},
                });

            modelBuilder.Entity<TaskEntity>().HasData(
                new TaskEntity[]
                {
                    new TaskEntity { Id = 1, Name ="Create", CreatorId=1, PerformerId=2, Description="", Status=Statuses.NotStarted},
                    new TaskEntity { Id = 2, Name ="Push", CreatorId=2, PerformerId=3, Description="", Status=Statuses.NotStarted},
                    new TaskEntity { Id = 3, Name ="Delete", CreatorId=3, PerformerId=4, Description="", Status=Statuses.NotStarted},
                    new TaskEntity { Id = 4, Name ="Read", CreatorId=4, PerformerId=5, Description="", Status=Statuses.NotStarted},
                    new TaskEntity { Id = 5, Name ="Edit", CreatorId=5, PerformerId=1, Description="", Status=Statuses.NotStarted},

                });
        }
    }
}
