using AutoMapper;
using MediatR;
using MyPeopleHub.Domain.Interfaces;

namespace MyPeopleHub.Application.Friendship.Commands.CreateFrienship
{
    public class CreateFriendshipCommandHandler : IRequestHandler<CreateFrienshipCommand, string>
    {
        private readonly IFriendshipService _friendshipService;
        private readonly IMapper _mapper;
        public CreateFriendshipCommandHandler(IFriendshipService friendshipService, IMapper mapper)
        {
            _friendshipService = friendshipService;
            _mapper = mapper;
        }

        public Task<string> Handle(CreateFrienshipCommand request, CancellationToken cancellationToken)
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

            return _friendshipService.CreateFriendship(friendship);
        }
    }
}
