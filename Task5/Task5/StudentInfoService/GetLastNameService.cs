using Task5.Models;

namespace Task5.StudentInfoService
{
    public class GetLastNameService : IGetLastNameService
    {
        public string GetDiscription()
        {
            return "Last name of student";
        }

        public string GetInfo(Student student)
        {
            if (student is null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (student.LastName is null)
            {
                throw new ArgumentNullException(nameof(student.LastName));
            }

            if (string.IsNullOrEmpty(student.LastName))
            {
                throw new ArgumentException(nameof(student.LastName));
            }

            return $"LastName: {student.LastName}";
        }
    }
}
