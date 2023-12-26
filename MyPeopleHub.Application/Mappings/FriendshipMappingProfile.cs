using AutoMapper;
using MyPeopleHub.Application.Friendship.Commands.CreateFrienship;

namespace MyPeopleHub.Application.Mappings
{
    public class FriendshipMappingProfile : Profile
    {
        public FriendshipMappingProfile()
        {
            CreateMap<CreateFrienshipCommand, Domain.Entities.Friendship>();
        }
    }
}
