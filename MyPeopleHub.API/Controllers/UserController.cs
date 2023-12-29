using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPeopleHub.Application.User.Queries.GetAllUsers;
using MyPeopleHub.Application.User.Queries.GetUserById;
using MyPeopleHub.Domain.Models.Dtos;

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
        public async Task<IEnumerable<UserDto>> GetAllUsers()
            => await _mediator.Send(new GetAllUsersQuery());

        [HttpGet]
        [Route("/GetUserById/{userId}")]
        public async Task<UserDto> GetUserById(string userId)
            => await _mediator.Send(new GetUserByIdQuery(userId));
    }
}
