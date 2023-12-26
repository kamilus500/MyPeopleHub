using AutoMapper;
using MediatR;
using MyPeopleHub.Domain.Interfaces;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var users = await _userService.GetAllUsers();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
