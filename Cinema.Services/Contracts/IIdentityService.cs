namespace Cinema.Services.Contracts
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public interface IIdentityService
    {
        Task<IdentityResult> Register(string username, string email, string password);

        string GenerateJwtToker(string userId, string userName, string secret);
    }
}
