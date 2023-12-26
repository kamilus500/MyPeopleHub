using MediatR;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.Friendship.Queries.GetAllFriendshipsForUser
{
    public class GetAllFriendsForUserQuery : IRequest<IEnumerable<UserDto>>
    {
        public string UserId { get; set; }

        public GetAllFriendsForUserQuery(string userId)
        {
            UserId = userId;
        }
    }
}
