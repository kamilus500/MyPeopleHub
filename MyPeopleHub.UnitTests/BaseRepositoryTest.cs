using Microsoft.EntityFrameworkCore;
using MyPeopleHub.Infrastructure.Persistance;

namespace MyPeopleHub.UnitTests
{
    public class BaseRepositoryTest
    {
        protected ApplicationDbContext DbContext;
        public BaseRepositoryTest()
        {
            DbContext = GetMemoryContext();
        }

        private ApplicationDbContext GetMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;
            return new ApplicationDbContext(options);
        }
    }
}
