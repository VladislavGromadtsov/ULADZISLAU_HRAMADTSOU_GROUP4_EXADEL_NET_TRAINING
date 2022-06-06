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
            return $"LastName: {student.LastName}";
        }
    }
}
