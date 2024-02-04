using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPeopleHub.Application.Friendship.Commands.CreateFrienship;
using MyPeopleHub.Application.Friendship.Queries.GetAllFriendshipsForUser;

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
        public async Task<IActionResult> CreateFriendship([FromBody]CreateFrienshipCommand command)
        {
            var friendshipId = await _mediator.Send(command);

            var reverseCommand = new CreateFrienshipCommand()
            {
                UserId = command.FriendId,
                FriendId = command.UserId,
            };

            var secondFriendshipId = await _mediator.Send(reverseCommand);

            return Created($"/CreateFriendship/{friendshipId}-{secondFriendshipId}", new List<string>() { friendshipId, secondFriendshipId });
        }

        [HttpGet]
        [Route("/GetAllFriendsForUser/{userId}")]
        public async Task<IActionResult> GetAllFriendsForUser(string userId)
        {
            var userDtos = await _mediator.Send(new GetAllFriendsForUserQuery(userId));

            return Ok(userDtos);
        }
    }
}