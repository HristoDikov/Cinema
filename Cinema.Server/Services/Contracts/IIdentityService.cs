namespace Cinema.Server.Services.Contracts
{
    public interface IIdentityService
    {
        string GenerateJwtToker(string userId, string userName, string secret);
    }
}
