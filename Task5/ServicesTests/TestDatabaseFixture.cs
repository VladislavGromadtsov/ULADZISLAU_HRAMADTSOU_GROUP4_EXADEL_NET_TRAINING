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
