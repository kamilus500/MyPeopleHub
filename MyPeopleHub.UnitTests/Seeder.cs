using MyPeopleHub.Domain.Entities;
using MyPeopleHub.Infrastructure.Persistance;

namespace MyPeopleHub.UnitTests
{
    public static class Seeder
    {
        public static void SeedData(this ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            var users = new List<User>()
                {
                    new User()
                    {
                        FirstName = "user",
                        LastName = "user",
                        Email = "user@gmail.com",
                        Login = "admin",
                        PasswordHashed = "dc7rATsXiWVSEw/GDoGK2Q==;yH3YvO06chyq6v3BVPfIZ1hjCNM0JD7PRj19OHIyt8Q="
                    },
                    new User()
                    {
                        FirstName = "user2",
                        LastName = "user2",
                        Email = "user2@gmail.com",
                        Login = "admin2",
                        PasswordHashed = "dc7rATsXiWVSEw/GDoGK2Q==;yH3YvO06chyq6v3BVPfIZ1hjCNM0JD7PRj19OHIyt8Q="
                    },
                    new User()
                    {
                        FirstName = "user3",
                        LastName = "user3",
                        Email = "user3@gmail.com",
                        Login = "admin3",
                        PasswordHashed = "dc7rATsXiWVSEw/GDoGK2Q==;yH3YvO06chyq6v3BVPfIZ1hjCNM0JD7PRj19OHIyt8Q="
                    },
                };

            string userId = Guid.NewGuid().ToString();
            string user2Id = Guid.NewGuid().ToString();
            string user3Id = Guid.NewGuid().ToString();

            users[0].Id = userId;
            users[1].Id = user2Id;
            users[2].Id = user3Id;

            dbContext.AddRange(users);
            dbContext.SaveChanges();


            var friendship = new Friendship()
            {
                UserId = userId,
                FriendId = user2Id
            };

            dbContext.Friendships.Add(friendship);
            dbContext.SaveChanges();
        }
    }
}
