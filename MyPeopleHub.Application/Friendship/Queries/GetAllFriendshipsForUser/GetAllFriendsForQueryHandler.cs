using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyPeopleHub.Domain.Interfaces;
using MyPeopleHub.Domain.Models.Dtos;
using MyPeopleHub.Infrastructure.Repositories;

namespace MyPeopleHub.Application.Friendship.Queries.GetAllFriendshipsForUser
{
    public class GetAllFriendsForQueryHandler : IRequestHandler<GetAllFriendsForUserQuery, IEnumerable<UserDto>>
    {
        private readonly IFriendshipService _friendshipService;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public string cacheKey = "AllFriendshipsFor";
        public GetAllFriendsForQueryHandler(IFriendshipService friendshipService, IMapper mapper, IMemoryCache memoryCache)
        {
            _friendshipService = friendshipService ?? throw new ArgumentNullException(nameof(friendshipService));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllFriendsForUserQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserId)) 
            {
                throw new ArgumentNullException(nameof(request.UserId));
            }
            
            cacheKey += $"-{request.UserId}";

            IEnumerable<Domain.Entities.User> friends;

            if (!_memoryCache.TryGetValue(cacheKey, out friends))
            {

                friends = await _friendshipService.GetAllFriendshipsForUser(request.UserId);

                _memoryCache.Set(cacheKey, friends,
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3)));
            }

            return _mapper.Map<IEnumerable<UserDto>>(friends);
        }
    }
}
