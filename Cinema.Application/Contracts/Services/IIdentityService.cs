namespace Cinema.Application.Contracts.Services
{
    using System.Threading.Tasks;
    //using Microsoft.AspNet.Identity;

    public interface IIdentityService
    {
        //Task<IdentityResult> Register(string username, string email, string password);

        string GenerateJwtToker(string userId, string userName, string secret);
    }
}
