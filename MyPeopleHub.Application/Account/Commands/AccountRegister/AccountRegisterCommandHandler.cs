using AutoMapper;
using MediatR;
using MyPeopleHub.Domain.Interfaces;

namespace MyPeopleHub.Application.Account.Commands.AccountRegister
{
    public class AccountRegisterCommandHandler : IRequestHandler<AccountRegisterCommand, string>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountRegisterCommandHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<string> Handle(AccountRegisterCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var newUser = _mapper.Map<Domain.Entities.User>(request);

            newUser.PasswordHashed = request.Password;

            return await _accountService.RegisterUser(newUser);
        }
    }
}
