﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task5;

#nullable disable

namespace Task5.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220524155411_AddedStudentDateOfBirth")]
    partial class AddedStudentDateOfBirth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClassSubject", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.HasKey("ClassesId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("ClassSubject", (string)null);

                    b.HasData(
                        new
                        {
                            ClassesId = 1,
                            SubjectsId = 2
                        },
                        new
                        {
                            ClassesId = 2,
                            SubjectsId = 3
                        },
                        new
                        {
                            ClassesId = 3,
                            SubjectsId = 4
                        },
                        new
                        {
                            ClassesId = 4,
                            SubjectsId = 1
                        });
                });

            modelBuilder.Entity("Task5.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Letter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Letter = "A",
                            Number = (byte)11
                        },
                        new
                        {
                            Id = 2,
                            Letter = "B",
                            Number = (byte)10
                        },
                        new
                        {
                            Id = 3,
                            Letter = "C",
                            Number = (byte)9
                        },
                        new
                        {
                            Id = 4,
                            Letter = "D",
                            Number = (byte)8
                        });
                });

            modelBuilder.Entity("Task5.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Gomel",
                            ClassId = 1,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ivan",
                            LastName = "Ivanov",
                            PhoneNumber = "375293522222"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Minsk",
                            ClassId = 2,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Vasya",
                            LastName = "Vasiliev",
                            PhoneNumber = "375293522223"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Grodno",
                            ClassId = 3,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Kostya",
                            LastName = "Kostilev",
                            PhoneNumber = "375293521223"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Gomel",
                            ClassId = 4,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Max",
                            LastName = "Maxov",
                            PhoneNumber = "375293511223"
                        });
                });

            modelBuilder.Entity("Task5.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Math"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Biology"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chemistry"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Phisics"
                        });
                });

            modelBuilder.Entity("ClassSubject", b =>
                {
                    b.HasOne("Task5.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task5.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Task5.Models.Student", b =>
                {
                    b.HasOne("Task5.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Task5.Models.Class", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}