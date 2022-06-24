using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
        public void Get_Test_Student_LastNames()
        {
            var id = 5;
            var lastName = "test1";
            var expected = $"LastName: {lastName}";
            using var context = Fixture.CreateContext();
            var studentInfoService = new GetStudentsInfoService(context, infoStringFormatterServices, new SchoolRepository<Student>(context));

            context.Add(new Student() { Id = id, LastName = lastName});
            studentInfoService.SetStrategy(_lastNameService);
            var result = studentInfoService.GetInfoByIdAsync(id).Result;

            context.ChangeTracker.Clear();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Get_Test_Student_FullInfo()
        {
            var id = 5;
            var firstName = "test2";
            var lastName = "test2";
            var phoneNumber = "375293522222";
            var dateOfBirth = DateTime.Now;
            var expected = new StringBuilder();
            expected.AppendLine($"Id: {id}");
            expected.AppendLine($"FirstName: {firstName}");
            expected.AppendLine($"LastName: {lastName}");
            expected.AppendLine($"PhoneNumber: {phoneNumber}");
            expected.AppendLine($"DateOfBirth: {dateOfBirth.ToString("D")}");
            using var context = Fixture.CreateContext();

            context.Database.BeginTransaction();
            var studentInfoService = new GetStudentsInfoService(context, infoStringFormatterServices, new SchoolRepository<Student>(context));

            context.Add(new Student() { Id = id, FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, DateOfBirth = dateOfBirth });
            studentInfoService.SetStrategy(_fullInfoService);
            var result = studentInfoService.GetInfoByIdAsync(id).Result;

            context.ChangeTracker.Clear();

            Assert.Equal(expected.ToString(), result);
        }
    }
}
