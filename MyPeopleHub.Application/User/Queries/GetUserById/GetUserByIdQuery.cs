using MediatR;

namespace MyPeopleHub.Application.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public string UserId { get; set; }

        public GetUserByIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
