using MediatR;

namespace MyPeopleHub.Application.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
