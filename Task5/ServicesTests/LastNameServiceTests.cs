using System;
using Task5.Models;
using Task5.StudentInfoService;
using Xunit;

namespace ServicesTests
{
    public class LastNameServiceTests
    {
        private readonly GetLastNameService lastNameService;

        public LastNameServiceTests()
        {
            lastNameService = new GetLastNameService();
        }

        [Fact]
        public void Get_Discription_Last_Name_Service()
        {
            var expected = "Last name of student";

            var result = lastNameService.GetDiscription();

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Get_Last_Name_Info_1()
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
            var expected = $"LastName: {lastName}";

            var result = lastNameService.GetInfo(student);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Get_Last_Name_Info_2()
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
            var expected = $"LastName: {lastName}";

            var result = lastNameService.GetInfo(student);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Get_Last_Name_Info_3()
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
            var expected = $"LastName: {lastName}";

            var result = lastNameService.GetInfo(student);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void Get_Info_Throw_ArgumentNullException_If_Student_Is_Null()
        {
            Student student = null;

            Assert.Throws<ArgumentNullException>(() => lastNameService.GetInfo(student));
        }

        [Fact]
        public void Get_Info_Throw_ArgumentNullException_If_Student_LastName_Is_Null()
        {
            Student student = new Student();

            Assert.Throws<ArgumentNullException>(() => lastNameService.GetInfo(student));
        }

        [Fact]
        public void Get_Info_Throw_ArgumentException_If_Student_LastName_Is_Empty()
        {
            Student student = new Student() { LastName = string.Empty };

            Assert.Throws<ArgumentException>(() => lastNameService.GetInfo(student));
        }
    }
}
