
using AutoMapper;
using MyPeopleHub.Application.User.Queries;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Domain.Entities.User, UserDto>();

            CreateMap<RegisterUserDto, Domain.Entities.User>();

            CreateMap<LoginDto, Domain.Entities.User>();
        }
    }
}
