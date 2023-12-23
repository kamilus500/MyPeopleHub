using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<string> RegisterUser(RegisterUserDto dto);

        Task<string> GenerateJwt(LoginDto dto);
    }
}
