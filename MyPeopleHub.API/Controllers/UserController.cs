using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPeopleHub.Application.User.Queries.GetAllUsers;
using MyPeopleHub.Application.User.Queries.GetUserById;

namespace MyPeopleHub.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [Route("/GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            return Ok(users);
        }

        [HttpGet]
        [Route("/GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(userId));

            if (user is null)
                return NotFound($"Not found user with id: {userId}");

            return Ok(user);
        }
    }
}
