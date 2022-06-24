using Microsoft.EntityFrameworkCore;
using Task5;
using Task5.Models;

namespace ServicesTests
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=School_2;Trusted_Connection=True;";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        context.AddRange(
                            new Student { FirstName = "test1", LastName = "test1", PhoneNumber = "375293522222", Address = "test1", ClassId = 1, DateOfBirth = System.DateTime.Now },
                            new Student { FirstName = "test2", LastName = "test2", PhoneNumber = "375293522222", Address = "test2", ClassId = 2, DateOfBirth = System.DateTime.Now },
                            new Student { FirstName = "test3", LastName = "test3", PhoneNumber = "375293522222", Address = "test3", ClassId = 3, DateOfBirth = System.DateTime.Now }
                        );
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public ApplicationContext CreateContext()
            => new ApplicationContext(
                new DbContextOptionsBuilder<ApplicationContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
    }
}
