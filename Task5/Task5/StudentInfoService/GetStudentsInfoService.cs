using Task5.DataAccessLayer;
using Task5.Models;

namespace Task5.StudentInfoService
{
    public class GetStudentsInfoService : IGetStudentsInfoService
    {
        private readonly IEnumerable<IInfoStringFormatterService> _infoStringFormatterServices;
        private IInfoStringFormatterService _currentFormat;
        private readonly ApplicationContext _context;
        public SchoolRepository<Student> _studentRep { get; }

        public GetStudentsInfoService(ApplicationContext applicationContex, IEnumerable<IInfoStringFormatterService> infoStringFormatterServices, SchoolRepository<Student> schoolRepository)
        {
            _infoStringFormatterServices = infoStringFormatterServices;
            _currentFormat = infoStringFormatterServices.FirstOrDefault();
            _context = applicationContex;
            _studentRep = schoolRepository;
        }

        public IEnumerable<IInfoStringFormatterService> GetAllFormats() => _infoStringFormatterServices;

        public void SetStrategy(IInfoStringFormatterService infoStringFormatterService)
        {
            this._currentFormat = infoStringFormatterService;
        }

        public void GetInfoById(int id)
        {
            var result = string.Empty;

            var student = _context.Students.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                result = this._currentFormat.GetInfo(student);

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("There are no such student");
            }
        }

        public async Task<string> GetInfoByIdAsync(int id)
        {
            var result = string.Empty;
            var student = await _studentRep.GetItemAsync(id);

            if (student != null)
            {
                result = _currentFormat.GetInfo(student);

                return result;
            }
            else
            {
                return "There are no such student";
            }
        }
    }
}
