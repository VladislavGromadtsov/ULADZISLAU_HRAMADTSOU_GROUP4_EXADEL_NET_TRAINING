using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.DataAccessLayer.Enums;

namespace TaskManagementSystem.DataAccessLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    new RoleEntity { Id = 1, Name = "TeamLead" },
                    new RoleEntity { Id = 2, Name ="Senior"},
                    new RoleEntity { Id = 3, Name ="Middle"},
                    new RoleEntity { Id = 4, Name ="Junior"}
                });

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity[]
                {
                    new UserEntity { Id = 1, FullName ="Ivan Ivanov", RoleId=1,Email ="ivan@gmail.com", Password="ivanivan"},
                    new UserEntity { Id = 2, FullName ="Vasya Vasiliev", RoleId=2, Email="vasya@gmail.com", Password="123"},
                    new UserEntity { Id = 3, FullName ="Petya Petrov", RoleId=3, Email="petya@gmail.com", Password ="qwerty"},
                    new UserEntity { Id = 4, FullName ="Katya Vasilenko", RoleId=4, Email="Katya@gmail.com", Password ="qwerty123"},
                    new UserEntity { Id = 5, FullName ="Vika Viktorieva", RoleId=1, Email="vika@gmail.com", Password ="qwerty111"},
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
