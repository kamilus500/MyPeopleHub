using AutoMapper;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Domain.Entities.User, UserDto>()
                .ForMember(u => u.FriendIds, src => src.MapFrom(u => u.Friendships.Select(f => f.FriendId)));

            CreateMap<RegisterUserDto, Domain.Entities.User>();

            CreateMap<LoginDto, Domain.Entities.User>();
        }
    }
}
