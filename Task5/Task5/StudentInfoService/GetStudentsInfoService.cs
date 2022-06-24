namespace Task5.StudentInfoService
{
    public class GetStudentsInfoService : IGetStudentsInfoService
    {
        private readonly IEnumerable<IInfoStringFormatterService> _infoStringFormatterServices;
        private IInfoStringFormatterService _currentFormat;
        private readonly ApplicationContext _context;

        public GetStudentsInfoService(ApplicationContext applicationContex, IEnumerable<IInfoStringFormatterService> infoStringFormatterServices)
        {
            this._infoStringFormatterServices = infoStringFormatterServices;
            this._currentFormat = infoStringFormatterServices.FirstOrDefault();
            this._context = applicationContex;
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
    }
}
