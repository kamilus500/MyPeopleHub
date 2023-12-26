using MediatR;
using MyPeopleHub.Domain.Interfaces;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.Account.Queries.AccountLogin
{
    public class AccountLoginQueryHandler : IRequestHandler<AccountLoginQuery, LoginResponse>
    {
        private readonly IAccountService _accountService;
        public AccountLoginQueryHandler(IAccountService accountService) => _accountService = accountService;

        public async Task<LoginResponse> Handle(AccountLoginQuery request, CancellationToken cancellationToken)
        {
            if (request.LoginDto is null)
            {
                throw new ArgumentNullException(nameof(request.LoginDto));
            }

            var token = await _accountService.GenerateJwt(request.LoginDto);

            return new LoginResponse
            {
                Token = token
            };
        }
    }
}
