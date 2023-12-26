using MediatR;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.Friendship.Commands.CreateFrienship
{
    public class CreateFrienshipCommand : CreateFriendshipDto, IRequest<string>
    {
    }
}
