using Microsoft.EntityFrameworkCore;
using MyPeopleHub.Domain.Entities;
using MyPeopleHub.Infrastructure.Persistance;
using MyPeopleHub.Infrastructure.Repositories;

namespace MyPeopleHub.UnitTests.RepositoriesTests
{
    public class FriendshipRepositoryTests
    {
        private readonly ApplicationDbContext dbContext;

        public FriendshipRepositoryTests()
        {
            var _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            dbContext = new ApplicationDbContext(_options);
            dbContext.SeedData();
        }

        [Fact]
        public async Task CreateFriendship()
        {

            var user = dbContext.Users.First();

            var newFriend = dbContext.Users.Last();

            var newFriendship = new Friendship()
            {
                UserId = user.Id,
                FriendId = newFriend.Id
            };

            var friendshipService = new FriendshipService(dbContext);

            var friendshipId = await friendshipService.CreateFriendship(newFriendship);

            Assert.NotNull(friendshipId);
            Assert.NotEmpty(friendshipId);
        }

        [Fact]
        public async Task GetAllFriendShipForUserId()
        {
            var user = dbContext.Users.First();

            var friendshipService = new FriendshipService(dbContext);

            var friends = await friendshipService.GetAllFriendshipsForUser(user.Id);

            Assert.NotNull(friends);
            Assert.Equal(1, friends.Count());
        }
    }
}
