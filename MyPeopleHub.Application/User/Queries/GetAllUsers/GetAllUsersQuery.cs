using MediatR;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
