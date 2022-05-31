namespace Task5.StudentInfoService
{
    public class GetStudentsInfoService
    {
        private IInfoStringFormatterService _infoStringFormatterService;
        private readonly ApplicationContext _context;

        public GetStudentsInfoService(ApplicationContext applicationContex)
        {
            _context = applicationContex;
            _infoStringFormatterService = new GetFullInfoService();
        }
        public GetStudentsInfoService(ApplicationContext applicationContex, IInfoStringFormatterService infoStringFormatterService)
        {
            this._infoStringFormatterService = infoStringFormatterService;
            this._context = applicationContex;
        }

        public void SetFormat(IInfoStringFormatterService infoStringFormatterService)
        {
            this._infoStringFormatterService = infoStringFormatterService;
        }

        public void GetInfoById(int id)
        {
            var result = string.Empty;
            var student = _context.Students.FirstOrDefault(x => x.Id == id);  
            
            if (student != null)
            {
                result = this._infoStringFormatterService.GetInfo(student);

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("There are no such student");
            }
        }
    }
}
