using Microsoft.EntityFrameworkCore;
using MyPeopleHub.Infrastructure.Persistance;
using MyPeopleHub.Infrastructure.Repositories;

namespace MyPeopleHub.UnitTests.RepositoriesTests
{
    public class UserRepositoryTests
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepositoryTests()
        {
            var _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            dbContext = new ApplicationDbContext(_options);
            dbContext.SeedData();
        }

        [Fact]
        public async Task GetAllUsers()
        {
            var userService = new UserService(dbContext);

            var users = await userService.GetAllUsers();

            Assert.Equal(3, users.Count());
            
        }
    }
}