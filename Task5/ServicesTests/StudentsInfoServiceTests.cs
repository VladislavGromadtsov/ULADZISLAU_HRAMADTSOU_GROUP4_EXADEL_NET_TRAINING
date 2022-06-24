using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task5.DataAccessLayer;
using Task5.Models;
using Task5.StudentInfoService;
using Xunit;

namespace ServicesTests
{
    public class StudentsInfoServiceTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly IInfoStringFormatterService _fullInfoService;
        private readonly IInfoStringFormatterService _lastNameService;
        private readonly IEnumerable<IInfoStringFormatterService> infoStringFormatterServices;
        public TestDatabaseFixture Fixture { get; }

        public StudentsInfoServiceTests(TestDatabaseFixture testDatabaseFixture)
        {
            Fixture = testDatabaseFixture;
            _fullInfoService = new GetFullInfoService();
            _lastNameService = new GetLastNameService();
            infoStringFormatterServices = new List<IInfoStringFormatterService>() { _fullInfoService, _lastNameService };
        } 

        [Fact]
        public void Get_Test_Student()
        {
            var id = 5;
            var lastName = "test1";
            var expected = $"LastName: {lastName}";
            using var context = Fixture.CreateContext();
            var studentInfoService = new GetStudentsInfoService(context, infoStringFormatterServices, new SchoolRepository<Student>(context));

            studentInfoService.SetStrategy(_lastNameService);
            var result = studentInfoService.GetInfoByIdAsync(id).Result;

            Assert.Equal(expected, result);
        }
    }
}
