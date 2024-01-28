using AutoMapper;
using MediatR;
using MyPeopleHub.Domain.Interfaces;

namespace MyPeopleHub.Application.Friendship.Commands.CreateFrienship
{
    public class CreateFriendshipCommandHandler : IRequestHandler<CreateFrienshipCommand, string>
    {
        private readonly IFriendshipService _friendshipService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public CreateFriendshipCommandHandler(IFriendshipService friendshipService, IMapper mapper, IUserService userService)
        {
            _friendshipService = friendshipService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<string> Handle(CreateFrienshipCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.FriendId))
            {
                throw new ArgumentNullException(nameof(request.FriendId));
            }

            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException(nameof(request.UserId));
            }

            var friendship = _mapper.Map<Domain.Entities.Friendship>(request);

            var friendshipId = await _friendshipService.CreateFriendship(friendship);

            if (friendshipId != null)
            {
                await _userService.UpdateUserCount(request.UserId);
                await _userService.UpdateUserCount(request.FriendId);
            }            

            return friendshipId;
        }
    }
}
