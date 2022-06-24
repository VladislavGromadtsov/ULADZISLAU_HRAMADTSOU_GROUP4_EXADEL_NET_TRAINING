namespace Task5.StudentInfoService
{
    public interface IGetStudentsInfoService
    {
        public IEnumerable<IInfoStringFormatterService> GetAllFormats();
        void GetInfoById(int id);
        void SetStrategy(IInfoStringFormatterService infoStringFormatterService);
    }
}