using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task5.Models;

namespace Task5;

public static class Program
{
    static async Task Main(string[] args)
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
                "5. Create subject Async\n" +
                "6. Update subject by ID Async\n" +
                "7. Delete subject by ID Async\n" +
                "8. Read subject by ID Async\n" +
                "0. Exit\n\n" +
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
                        await CreateSubjectAsync(options);
                        break;
                    case "6":
                        await UpdateSubjectAsync(options);
                        break;
                    case "7":
                        await DeleteSubjectAsync(options);
                        break;
                    case "8":
                        await ReadSubjectAsync(options);
                        break;
                    case "0":
                        return;
                }
            }

            Console.Clear();
        }
    }

    private static async Task<Subject?> GetSubjectAsync(DbContextOptions<ApplicationContext> options, int subjectID, bool includeClasses = false)
    {
        Subject? subject = null;
        using (ApplicationContext db = new ApplicationContext(options))
        {
            if (includeClasses)
            {
                subject = await db.Subjects.Include(c => c.Classes).FirstOrDefaultAsync(sb => sb.Id == subjectID);
            }
            else
            {
                subject = await db.Subjects.FirstOrDefaultAsync(sb => sb.Id == subjectID);
            }
        }

        return subject;
    }

    private static async Task ReadSubjectAsync(DbContextOptions<ApplicationContext> options)
    {
        Console.Write("Input subject ID: ");
        var subjectID = Convert.ToInt32(Console.ReadLine());

        var subject = await GetSubjectAsync(options, subjectID, true);
             
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

        Console.ReadKey();
    }
    private static async Task UpdateSubjectAsync(DbContextOptions<ApplicationContext> options)
    {
        Console.Write("Input subject ID: ");
        var subjectID = Convert.ToInt32(Console.ReadLine());

        var subject = await GetSubjectAsync(options, subjectID);

        if (subject != null)
        {
            Console.WriteLine($"ID:\t{subject.Id}\n" +
            $"Name:\t{subject.Name}");

            using (ApplicationContext db = new ApplicationContext(options))
            {
                while (true)
                {
                    Console.Write("Input subject name: ");
                    var subjectName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(subjectName))
                    {
                        subject.Name = subjectName;
                        await db.SaveChangesAsync();

                        Console.WriteLine($"Subject {subjectName} updated!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("There no such subject with this ID");
        }

        Console.ReadKey();
    }
    private static async Task DeleteSubjectAsync(DbContextOptions<ApplicationContext> options)
    {
        Console.Write("Input subject ID: ");
        var subjectID = Convert.ToInt32(Console.ReadLine());

        var subject = await GetSubjectAsync(options, subjectID);

        if (subject != null)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.Subjects.Remove(subject);
                await db.SaveChangesAsync();
                Console.WriteLine($"Subject {subject.Name} successfuly deleted");
            }
        }
        else
        {
            Console.WriteLine("There no such subject with this ID");
        }

        Console.ReadKey();
    }

    private static async Task CreateSubjectAsync(DbContextOptions<ApplicationContext> options)
    {
        Console.Write("Input subject name: ");
        var subjectName = Console.ReadLine();
        if (!string.IsNullOrEmpty(subjectName))
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Subject subject = new Subject { Name = subjectName };

                db.Subjects.Add(subject);
                await db.SaveChangesAsync();
                Console.WriteLine($"Subject {subjectName} created!");
            }
        }
        else
        {
            Console.WriteLine("Incorrect input");
        }

        Console.ReadKey();
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
