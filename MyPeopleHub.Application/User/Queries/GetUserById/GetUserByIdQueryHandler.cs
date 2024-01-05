using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MyPeopleHub.Domain.Interfaces;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.User.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public string cacheKey = "UserById";

        public GetUserByIdQueryHandler(IUserService userService, IMapper mapper, IMemoryCache memoryCache)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentNullException(nameof(request.UserId));
            }

            cacheKey += $"-{request.UserId}";

            Domain.Entities.User user;

            if (!_memoryCache.TryGetValue(cacheKey, out user))
            {
                user = await _userService.GetUserById(request.UserId);

                _memoryCache.Set(cacheKey, user,
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30)));
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
