using AutoMapper;
using MediatR;
using MyPeopleHub.Domain.Interfaces;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.Friendship.Queries.GetAllFriendshipsForUser
{
    public class GetAllFriendsForQueryHandler : IRequestHandler<GetAllFriendsForUserQuery, IEnumerable<UserDto>>
    {
        private readonly IFriendshipService _friendshipService;
        private readonly IMapper _mapper;
        public GetAllFriendsForQueryHandler(IFriendshipService friendshipService, IMapper mapper)
        {
            _friendshipService = friendshipService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllFriendsForUserQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserId)) 
            {
                throw new ArgumentNullException(nameof(request.UserId));
            }

            var users = await _friendshipService.GetAllFriendshipsForUser(request.UserId);

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
