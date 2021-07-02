namespace Cinema.Services.Implementations
{
    using Data;
    using Contracts;
    using Data.Models;

    using System;
    using System.Text;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> userManager;
        private readonly CinemaDbContext db;

        public IdentityService(UserManager<User> userManager, CinemaDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<IdentityResult> Register(string username, string email, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = username
            };

            var result = await this.userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await this.db.SaveChangesAsync();
            }

            return result;
        }

        public string GenerateJwtToker(string userId, string userName, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
