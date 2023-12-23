using MediatR;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.Account.Queries.AccountLogin
{
    public class AccountLoginQuery : IRequest<LoginResponse>
    {
        public LoginDto LoginDto { get; set; }
    }
}
