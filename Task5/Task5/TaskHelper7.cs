using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DataAccessLayer;
using Task5.Models;

namespace Task5
{
    public class TaskHelper7
    {
        readonly IRepository<Class> classDb;
        readonly IRepository<Student> studentDb;
        readonly IRepository<Subject> subjectDb;

        public TaskHelper7(ApplicationContext applicationContext)
        {
            classDb = new SchoolRepository<Class>(applicationContext);
            subjectDb = new SchoolRepository<Subject>(applicationContext);
            studentDb = new SchoolRepository<Student>(applicationContext);
        }

        public void CreateSubject()
        {
            Console.Write("Input subject name: ");
            var subjectName = Console.ReadLine();
            if (!string.IsNullOrEmpty(subjectName))
            {
                Subject subject = new Subject { Name = subjectName };

                subjectDb.Create(subject);
                subjectDb.Save();

                Console.WriteLine($"Subject {subjectName} created!");
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }

        public void ReadSubject()
        {
            Console.Write("Input subject ID: ");
            var subjectID = Convert.ToInt32(Console.ReadLine());

            var subject = subjectDb.GetItem(subjectID);
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

        public void DeleteSubject()
        {
            Console.Write("Input subject ID: ");
            var subjectID = Convert.ToInt32(Console.ReadLine());

            var subject = subjectDb.GetItem(subjectID);
            if (subject != null)
            {
                Console.WriteLine($"ID:\t{subject.Id}\n" +
                    $"Name:\t{subject.Name}");

                subjectDb.Delete(subjectID);
                subjectDb.Save();

                Console.WriteLine($"Subject {subject.Name} successfuly deleted");
            }
            else
            {
                Console.WriteLine("There no such subject with this ID");
            }
        }

        public void UpdateSubject()
        {
            Console.Write("Input subject ID: ");
            var subjectID = Convert.ToInt32(Console.ReadLine());

            var subject = subjectDb.GetItem(subjectID);
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

                        subjectDb.Update(subject);
                        subjectDb.Save();

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
    }
}
