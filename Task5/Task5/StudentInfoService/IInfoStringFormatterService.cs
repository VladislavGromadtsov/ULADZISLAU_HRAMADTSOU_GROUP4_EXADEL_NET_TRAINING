using Task5.Models;

namespace Task5.StudentInfoService
{
    public interface IInfoStringFormatterService
    {
        public string GetInfo(Student student);
    }
}