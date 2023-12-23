using MediatR;
using MyPeopleHub.Domain.Interfaces;

namespace MyPeopleHub.Application.Account.Commands.AccountRegister
{
    public class AccountRegisterCommandHandler : IRequestHandler<AccountRegisterCommand, string>
    {
        private readonly IAccountService _accountService;
        public AccountRegisterCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<string> Handle(AccountRegisterCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await _accountService.RegisterUser(request);
        }
    }
}
