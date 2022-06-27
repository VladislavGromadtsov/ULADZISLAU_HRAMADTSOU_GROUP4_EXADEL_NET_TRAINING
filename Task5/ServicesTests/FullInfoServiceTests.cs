using System;
using System.Text;
using Task5.Models;
using Task5.StudentInfoService;
using Xunit;

namespace ServicesTests
{
    public class FullInfoServiceTests
    {
        private readonly GetFullInfoService fullInfoService;

        public FullInfoServiceTests()
        {
            fullInfoService = new GetFullInfoService();
        }

        [Fact]
        public void Get_Full_Info_1()
        {
            var id = 1;
            var firstName = "Ivan";
            var lastName = "Ivanov";
            var phoneNumber = "375293522222";
            var address = "Gomel";
            var classId = 1;
            var dateOfBirth = DateTime.Now;
            var student = new Student()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Address = address,
                ClassId = classId,
                DateOfBirth = dateOfBirth
            };
            var expected = new StringBuilder();
            expected.AppendLine($"Id: {id}");
            expected.AppendLine($"FirstName: {firstName}");
            expected.AppendLine($"LastName: {lastName}");
            expected.AppendLine($"PhoneNumber: {phoneNumber}");
            expected.AppendLine($"DateOfBirth: {dateOfBirth.ToString("D")}");

            var result = fullInfoService.GetInfo(student);

            Assert.Equal(expected.ToString(), result);
        }

        [Fact]
        public void Get_Full_Info_2()
        {
            var id = 3;
            var firstName = "Vlad";
            var lastName = "Grom";
            var phoneNumber = "375293521212";
            var address = "Minsk";
            var classId = 1;
            var dateOfBirth = DateTime.Now;
            var student = new Student()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Address = address,
                ClassId = classId,
                DateOfBirth = dateOfBirth
            };
            var expected = new StringBuilder();
            expected.AppendLine($"Id: {id}");
            expected.AppendLine($"FirstName: {firstName}");
            expected.AppendLine($"LastName: {lastName}");
            expected.AppendLine($"PhoneNumber: {phoneNumber}");
            expected.AppendLine($"DateOfBirth: {dateOfBirth.ToString("D")}");

            var result = fullInfoService.GetInfo(student);

            Assert.Equal(expected.ToString(), result);
        }

        [Fact]
        public void Get_Full_Info_3()
        {
            var id = 3;
            var firstName = "Katya";
            var lastName = "Baranova";
            var phoneNumber = "375293522212";
            var address = "Mogilev";
            var classId = 2;
            var dateOfBirth = DateTime.Now;
            var student = new Student()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Address = address,
                ClassId = classId,
                DateOfBirth = dateOfBirth
            };
            var expected = new StringBuilder();
            expected.AppendLine($"Id: {id}");
            expected.AppendLine($"FirstName: {firstName}");
            expected.AppendLine($"LastName: {lastName}");
            expected.AppendLine($"PhoneNumber: {phoneNumber}");
            expected.AppendLine($"DateOfBirth: {dateOfBirth.ToString("D")}");

            var result = fullInfoService.GetInfo(student);

            Assert.Equal(expected.ToString(), result);
        }


        [Fact]
        public void Get_Info_Throw_ArgumentNullException_If_Student_Is_Null()
        {
            Student student = null;

            Assert.Throws<ArgumentNullException>(() => fullInfoService.GetInfo(student));
        }

        [Fact]
        public void Get_Info_Throw_ArgumentNullException_If_Student_LastName_Is_Null()
        {
            Student student = new Student() { FirstName = "test", PhoneNumber = "37529" };

            Assert.Throws<ArgumentNullException>(() => fullInfoService.GetInfo(student));
        }

        [Fact]
        public void Get_Info_Throw_ArgumentNullException_If_Student_FirstName_Is_Null()
        {
            Student student = new Student() { LastName = "test", PhoneNumber = "37529" };

            Assert.Throws<ArgumentNullException>(() => fullInfoService.GetInfo(student));
        }

        [Fact]
        public void Get_Info_Throw_ArgumentNullException_If_Student_PhoneNumber_Is_Null()
        {
            Student student = new Student() { FirstName = "test", LastName = "test" };

            Assert.Throws<ArgumentNullException>(() => fullInfoService.GetInfo(student));
        }

        [Fact]
        public void Get_Info_Throw_ArgumentException_If_Student_LastName_Is_Empty()
        {
            Student student = new Student() { LastName = string.Empty, PhoneNumber = "test", FirstName = "test" };

            Assert.Throws<ArgumentException>(() => fullInfoService.GetInfo(student));
        }

        [Fact]
        public void Get_Info_Throw_ArgumentException_If_Student_FirstName_Is_Empty()
        {
            Student student = new Student() { LastName = "test", PhoneNumber = "test", FirstName = string.Empty };

            Assert.Throws<ArgumentException>(() => fullInfoService.GetInfo(student));
        }

        [Fact]
        public void Get_Info_Throw_ArgumentException_If_Student_PhoneNumber_Is_Empty()
        {
            Student student = new Student() { LastName = "test", PhoneNumber = string.Empty, FirstName = "test" };

            Assert.Throws<ArgumentException>(() => fullInfoService.GetInfo(student));
        }

        [Fact]
        public void Get_Discription_Full_Info_Service()
        {
            var fullInfoService = new GetFullInfoService();
            var result = fullInfoService.GetDiscription();

            var expected = "Full info about student";

            Assert.Equal(result, expected);
        }
    }
}
