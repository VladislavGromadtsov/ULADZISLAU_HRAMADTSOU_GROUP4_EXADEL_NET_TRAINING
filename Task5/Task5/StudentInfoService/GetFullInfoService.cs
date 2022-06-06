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
