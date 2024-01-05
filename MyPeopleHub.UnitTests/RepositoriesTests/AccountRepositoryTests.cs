using MyPeopleHub.Domain.Entities;
using MyPeopleHub.Domain.Models.Configs;
using MyPeopleHub.Infrastructure.Repositories;

namespace MyPeopleHub.UnitTests.RepositoriesTests
{
    public class AccountRepositoryTests : BaseRepositoryTest
    {
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

            var accountService = new AccountService(DbContext, authenticationSettings);

            var result = await accountService.RegisterUser(user);

            Assert.NotNull(result);
        }
    }
}
