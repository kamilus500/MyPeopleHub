using MyPeopleHub.Domain.Entities;

namespace MyPeopleHub.Domain.Interfaces
{
    public interface IFriendshipService
    {
        Task<IEnumerable<User>> GetAllFriendshipsForUser(string userId);

        Task<string> CreateFriendship(Friendship friendship);
    }
}
