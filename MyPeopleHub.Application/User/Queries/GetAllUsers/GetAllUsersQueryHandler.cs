using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyPeopleHub.Domain.Interfaces;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public string cacheKey = "AllUsers";

        public GetAllUsersQueryHandler(IUserService userService, IMapper mapper, IMemoryCache memoryCache)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            IEnumerable<Domain.Entities.User> users;

            if (!_memoryCache.TryGetValue(cacheKey, out users))
            {
                users = await _userService.GetAllUsers();

                _memoryCache.Set(cacheKey, users,
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(5)));
            }

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
