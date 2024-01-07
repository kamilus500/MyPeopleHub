using Microsoft.EntityFrameworkCore;
using MyPeopleHub.Domain.Entities;
using MyPeopleHub.Domain.Models.Configs;
using MyPeopleHub.Domain.Models.Dtos;
using MyPeopleHub.Infrastructure.Persistance;
using MyPeopleHub.Infrastructure.Repositories;

namespace MyPeopleHub.UnitTests.RepositoriesTests
{
    public class AccountRepositoryTests
    {
        private readonly ApplicationDbContext dbContext;
        public AccountRepositoryTests()
        {
            var _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            dbContext = new ApplicationDbContext(_options);
            dbContext.SeedData();
        }

        [Fact]
        public async Task RegisterNewUser()
        {
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "xxx@gmail.com",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Login = "testLogin",
                PasswordHashed = "testPassword",
            };

            var authenticationSettings = new AuthenticationSettings()
            {
                ValidAudience = "https://localhost:5001",
                ValidIssuer = "https://localhost:5001",
                TokenExpiryTimeInHour = 3,
                Secret = "ecawiasqrpqrgyhwnolrudpbsrwaynbqdayndnmcehjnwqyouikpodzaqxivwkconwqbhrmxfgccbxbyljguwlxhdlcvxlutbnwjlgpfhjgqbegtbxbvwnacyqnltrby"
            };

            var accountService = new AccountService(dbContext, authenticationSettings);
            string registerResponse = await accountService.RegisterUser(user);

            Assert.NotNull(registerResponse);
        }

        [Fact]
        public async Task GenerateJwt()
        {
            var loginDto = new LoginDto()
            {
                Login = "admin",
                Password = "admin1"
            };

            var authenticationSettings = new AuthenticationSettings()
            {
                ValidAudience = "https://localhost:5001",
                ValidIssuer = "https://localhost:5001",
                TokenExpiryTimeInHour = 3,
                Secret = "ecawiasqrpqrgyhwnolrudpbsrwaynbqdayndnmcehjnwqyouikpodzaqxivwkconwqbhrmxfgccbxbyljguwlxhdlcvxlutbnwjlgpfhjgqbegtbxbvwnacyqnltrby"
            };

            var accountService = new AccountService(dbContext, authenticationSettings);
            var token = await accountService.GenerateJwt(loginDto);

            Assert.NotNull(token);
            Assert.NotEmpty(token);
        }
    }
}
