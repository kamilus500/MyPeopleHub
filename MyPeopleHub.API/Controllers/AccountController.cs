using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPeopleHub.Application.Account.Commands.AccountRegister;
using MyPeopleHub.Application.Account.Queries.AccountLogin;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register([FromBody] AccountRegisterCommand registerCommand)
        {
            var userId = await _mediator.Send(registerCommand);

            return Created($"/register/{userId}", userId);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
            var loginResponse = await _mediator.Send(new AccountLoginQuery()
            {
                LoginDto = loginDto
            });

            if (string.IsNullOrEmpty(loginResponse.Token))
            {
                return BadRequest("Something is wrong: Token is empty");
            }

            return Ok(loginResponse);
        }
    }
}
