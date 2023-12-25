using AutoMapper;
using MediatR;
using MyPeopleHub.Domain.Interfaces;

namespace MyPeopleHub.Application.User.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException(nameof(request.UserId));
            }

            var user = await _userService.GetUserById(request.UserId);

            return _mapper.Map<UserDto>(user);
        }
    }
}
