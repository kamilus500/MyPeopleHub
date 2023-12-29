using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPeopleHub.Application.Friendship.Commands.CreateFrienship;
using MyPeopleHub.Application.Friendship.Queries.GetAllFriendshipsForUser;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FriendshipController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FriendshipController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        [Route("/CreateFriendship")]
        public async Task<string> CreateFriendship([FromBody]CreateFrienshipCommand command)
            => await _mediator.Send(command);

        [HttpGet]
        [Route("/GetAllFriendsForUser/{userId}")]
        public async Task<IEnumerable<UserDto>> GetAllFriendsForUser(string userId)
            => await _mediator.Send(new GetAllFriendsForUserQuery(userId));
    }
}