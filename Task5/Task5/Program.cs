using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task5.Models;

namespace Task5
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            while (true)
            {
                Console.Write("Menu:\n" +
                    "1. Create subject\n" +
                    "2. Update subject by ID\n" +
                    "3. Delete subject by ID\n" +
                    "4. Read subject by ID\n" +
                    "5. Exit\n\n" +
                    "Input: ");
                var choice = Console.ReadLine();
                if (choice != null)
                {
                    Console.Clear();

                    switch (choice)
                    {
                        case "1":
                            CreateSubject(options);
                            break;
                        case "2":
                            UpdateSubject(options);
                            break;
                        case "3":
                            DeleteSubject(options);
                            break;
                        case "4":
                            ReadSubject(options);
                            break;
                        case "5":
                            return;
                    }
                }

                Console.Clear();
            }
        }

        private static void ReadSubject(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Console.Write("Input subject ID: ");
                var subjectID = Convert.ToInt32(Console.ReadLine());

                var subject = db.Subjects.Include(c => c.Classes).FirstOrDefault(sb => sb.Id == subjectID);
                if (subject != null)
                {
                    Console.WriteLine($"ID:\t{subject.Id}\n" +
                        $"Name:\t{subject.Name}\n" +
                        "Classes:\t");

                    foreach (var c in subject.Classes)
                    {
                        Console.Write($"{c.Number}-{c.Letter}\t");
                    }
                }
                else
                {
                    Console.WriteLine("There no such subject with this ID");
                }
            }

            Console.ReadKey();
        }

        private static void DeleteSubject(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Console.Write("Input subject ID: ");
                var subjectID = Convert.ToInt32(Console.ReadLine());

                var subject = db.Subjects.FirstOrDefault(sb => sb.Id == subjectID);

                if (subject != null)
                {
                    Console.WriteLine($"ID:\t{subject.Id}\n" +
                        $"Name:\t{subject.Name}");
                    db.Subjects.Remove(subject);
                    db.SaveChanges();
                    Console.WriteLine($"Subject {subject.Name} successfuly deleted");
                }
                else
                {
                    Console.WriteLine("There no such subject with this ID");
                }
            }

            Console.ReadKey();
        }

        private static void UpdateSubject(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Console.Write("Input subject ID: ");
                var subjectID = Convert.ToInt32(Console.ReadLine());

                var subject = db.Subjects.FirstOrDefault(sb => sb.Id == subjectID);

                if (subject != null)
                {
                    Console.WriteLine($"ID:\t{subject.Id}\n" +
                    $"Name:\t{subject.Name}");

                    while (true)
                    {
                        Console.Write("Input subject name: ");
                        var subjectName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(subjectName))
                        {
                            subject.Name = subjectName;
                            db.SaveChanges();

                            Console.WriteLine($"Subject {subjectName} updated!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There no such subject with this ID");
                }
            }

            Console.ReadKey();
        }

        private static void CreateSubject(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Console.Write("Input subject name: ");
                var subjectName = Console.ReadLine();
                if (!string.IsNullOrEmpty(subjectName))
                {
                    Subject subject = new Subject { Name = subjectName };

                    db.Subjects.Add(subject);
                    db.SaveChanges();
                    Console.WriteLine($"Subject {subjectName} created!");
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }

            Console.ReadKey();
        }
    }
}