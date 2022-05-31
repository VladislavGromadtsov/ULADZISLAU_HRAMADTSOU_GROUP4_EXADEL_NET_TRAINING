using Task5.Models;

namespace Task5.StudentInfoService
{
    public class GetLastNameService : IInfoStringFormatterService
    {
        public string GetInfo(Student student)
        {
            return $"LastName: {student.LastName}";
        }
    }
}
