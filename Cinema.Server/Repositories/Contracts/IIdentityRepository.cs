namespace Cinema.Server.Repositories.Contracts
{
    public interface IIdentityRepository
    {
        string GenerateJwtToker(string userId, string userName, string secret);
    }
}
