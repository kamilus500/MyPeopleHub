using MyPeopleHub.Domain.Entities;

namespace MyPeopleHub.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(string id);

        Task<IEnumerable<User>> GetAllUsers();

        Task<User> UpdateUserCount(string userId);
    }
}
