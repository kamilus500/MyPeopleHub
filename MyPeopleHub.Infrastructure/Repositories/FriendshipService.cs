using Microsoft.EntityFrameworkCore;
using MyPeopleHub.Domain.Entities;
using MyPeopleHub.Domain.Interfaces;
using MyPeopleHub.Infrastructure.Persistance;

namespace MyPeopleHub.Infrastructure.Repositories
{
    public class FriendshipService : IFriendshipService
    {
        private readonly ApplicationDbContext _dbContext;
        public FriendshipService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateFriendship(Friendship friendship)
        {
            await _dbContext.Friendships.AddAsync(friendship);
            await _dbContext.SaveChangesAsync();

            return $"{friendship.UserId} {friendship.FriendId}";
        }

        public async Task<IEnumerable<User>> GetAllFriendshipsForUser(string userId)
        {
            var friendShips = await _dbContext.Friendships
                                        .Where(x => x.UserId == userId)
                                        .Include(x => x.User)
                                        .Include(x => x.Friend)
                                        .AsNoTracking()
                                        .ToListAsync();

            return friendShips
                    .Select(x => x.Friend)
                    .ToList();
        }
    }
}