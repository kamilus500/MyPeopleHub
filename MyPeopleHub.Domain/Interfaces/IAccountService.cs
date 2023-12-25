using MyPeopleHub.Domain.Models.Dtos;

namespace MyPeopleHub.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<string> RegisterUser(Entities.User newUser);

        Task<string> GenerateJwt(LoginDto dto);
    }
}
