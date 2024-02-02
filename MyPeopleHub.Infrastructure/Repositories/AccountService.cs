using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyPeopleHub.Domain.Entities;
using MyPeopleHub.Domain.Interfaces;
using MyPeopleHub.Domain.Models.Configs;
using MyPeopleHub.Domain.Models.Dtos;
using MyPeopleHub.Infrastructure.Persistance;
using MyPeopleHub.Infrastructure.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyPeopleHub.Infrastructure.Repositories
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AuthenticationSettings _authenticationSettings;
        public AccountService(ApplicationDbContext dbContext, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<string> GenerateJwt(LoginDto dto)
        {
            var user = await _dbContext.Users
                .AsNoTracking()    
                .FirstOrDefaultAsync(x => x.Login == dto.Login);

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = PasswordHasher.Validate(user.PasswordHashed,dto.Password);
            if (!result)
            {
                throw new ArgumentException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("FullName", $"{user.FirstName} {user.LastName}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.Secret));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.TokenExpiryTimeInHour);

            var token = new JwtSecurityToken(_authenticationSettings.ValidIssuer,
                _authenticationSettings.ValidIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> RegisterUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();

            var hashedPassword = PasswordHasher.Hash(user.PasswordHashed);

            user.PasswordHashed = hashedPassword;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
