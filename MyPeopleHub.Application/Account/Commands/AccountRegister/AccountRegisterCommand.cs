using MediatR;
using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Application.Account.Commands.AccountRegister
{
    public class AccountRegisterCommand : RegisterUserDto, IRequest<string>
    {
    }
}
