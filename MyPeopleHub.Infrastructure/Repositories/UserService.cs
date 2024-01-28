using Microsoft.EntityFrameworkCore;
using MyPeopleHub.Domain.Entities;
using MyPeopleHub.Domain.Interfaces;
using MyPeopleHub.Infrastructure.Persistance;

namespace MyPeopleHub.Infrastructure.Repositories
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
            => await _dbContext.Users.AsNoTracking().ToListAsync();

        public async Task<User> GetUserById(string id)
            => await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<User> UpdateUserCount(string userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.CountOfFriends += 1;

            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
