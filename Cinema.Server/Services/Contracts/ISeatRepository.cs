namespace Cinema.Server.Services.Contracts
{
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface ISeatRepository
    {
        Task CreateSeats(IProjectionCreation projection);
    }
}
