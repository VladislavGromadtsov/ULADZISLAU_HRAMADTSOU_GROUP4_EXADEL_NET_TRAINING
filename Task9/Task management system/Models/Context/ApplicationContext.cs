using Microsoft.EntityFrameworkCore;
using Task_management_system.Models;
using System.Configuration;

namespace Task_management_system.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.Creator)
                .WithMany(u => u.TasksCreator)
                .HasForeignKey(t => t.CreatorId)
                .IsRequired(true);

            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.Performer)
                .WithMany(u => u.TasksPerformer)
                .HasForeignKey(t => t.PerformerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role { Id = 1, Name = "TeamLead" },
                    new Role { Id = 2, Name ="Senior"},
                    new Role { Id = 3, Name ="Middle"},
                    new Role { Id = 4, Name ="Junior"}
                });

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id = 1, FullName ="Ivan Ivanov", RoleId=1,Email ="ivan@gmail.com", Password="ivanivan"},
                    new User { Id = 2, FullName ="Vasya Vasiliev", RoleId=2, Email="vasya@gmail.com", Password="123"},
                    new User { Id = 3, FullName ="Petya Petrov", RoleId=3, Email="petya@gmail.com", Password ="qwerty"},
                    new User { Id = 4, FullName ="Katya Vasilenko", RoleId=4, Email="Katya@gmail.com", Password ="qwerty123"},
                    new User { Id = 5, FullName ="Vika Viktorieva", RoleId=1, Email="vika@gmail.com", Password ="qwerty111"},
                });
        }
    }
}
