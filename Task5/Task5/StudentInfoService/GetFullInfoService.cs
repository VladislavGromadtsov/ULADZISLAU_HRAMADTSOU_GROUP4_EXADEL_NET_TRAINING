using System.Text;
using Task5.Models;

namespace Task5.StudentInfoService
{
    public class GetFullInfoService : IGetFullInfoService
    {
        public string GetDiscription()
        {
            return "Full info about student";
        }

        public string GetInfo(Student student)
        {
            if (student is null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (student.LastName is null || student.FirstName is null || student.PhoneNumber is null)
            {
                throw new ArgumentNullException(nameof(student), "Check info. It should be not null");
            }

            if (string.IsNullOrEmpty(student.LastName) || string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.PhoneNumber))
            {
                throw new ArgumentException("Info should be not empty", nameof(student));
            }

            var info = new StringBuilder();
            info.AppendLine($"Id: {student.Id}");
            info.AppendLine($"FirstName: {student.FirstName}");
            info.AppendLine($"LastName: {student.LastName}");
            info.AppendLine($"PhoneNumber: {student.PhoneNumber}");
            info.AppendLine($"DateOfBirth: {student.DateOfBirth.ToString("D")}");

            return info.ToString();
        }
    }
}
