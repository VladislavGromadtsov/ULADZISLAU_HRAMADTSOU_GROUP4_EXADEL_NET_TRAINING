using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Models;

namespace Task5
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var subject1 = new Subject() { Id = 1, Name = "Math" };
            var subject2 = new Subject() { Id = 2, Name = "Biology" };
            var subject3 = new Subject() { Id = 3, Name = "Chemistry" };
            var subject4 = new Subject() { Id = 4, Name = "Phisics" };

            var class1 = new Class() { Id = 1, Number = 11, Letter = "A" };
            var class2 = new Class() { Id = 2, Number = 10, Letter = "B" };
            var class3 = new Class() { Id = 3, Number = 9, Letter = "C" };
            var class4 = new Class() { Id = 4, Number = 8, Letter = "D" };

            var student1 = new Student() { Id = 1, FirstName = "Ivan", LastName = "Ivanov", PhoneNumber = "375293522222", Address = "Gomel", ClassId = 1 };
            var student2 = new Student() { Id = 2, FirstName = "Vasya", LastName = "Vasiliev", PhoneNumber = "375293522223", Address = "Minsk", ClassId = 2 };
            var student3 = new Student() { Id = 3, FirstName = "Kostya", LastName = "Kostilev", PhoneNumber = "375293521223", Address = "Grodno", ClassId = 3 };
            var student4 = new Student() { Id = 4, FirstName = "Max", LastName = "Maxov", PhoneNumber = "375293511223", Address = "Gomel", ClassId = 4 };

            modelBuilder.Entity<Class>().HasData(
                new Class[]
                {
                    class1, class2, class3, class4
                });

            modelBuilder.Entity<Student>().HasData(
                new Student[]
                {
                    student1, student2, student3, student4
                });

            modelBuilder.Entity<Subject>().HasData(
                new Subject[]
                {
                    subject1, subject2, subject3, subject4
                });

            modelBuilder.Entity<Class>()
                .HasMany(s => s.Subjects)
                .WithMany(c => c.Classes)
                .UsingEntity(j => j
                .ToTable("ClassSubject")
                .HasData(new
                {
                    ClassesId = 1, SubjectsId = 2
                }));

            modelBuilder.Entity<Class>()
                .HasMany(s => s.Subjects)
                .WithMany(c => c.Classes)
                .UsingEntity(j => j
                .ToTable("ClassSubject")
                .HasData(new
                {
                    ClassesId = 2,
                    SubjectsId = 3
                }));

            modelBuilder.Entity<Class>()
                .HasMany(s => s.Subjects)
                .WithMany(c => c.Classes)
                .UsingEntity(j => j
                .ToTable("ClassSubject")
                .HasData(new
                {
                    ClassesId = 3,
                    SubjectsId = 4
                }));

            modelBuilder.Entity<Class>()
                .HasMany(s => s.Subjects)
                .WithMany(c => c.Classes)
                .UsingEntity(j => j
                .ToTable("ClassSubject")
                .HasData(new
                {
                    ClassesId = 4,
                    SubjectsId = 1
                }));
        }
    }
}
