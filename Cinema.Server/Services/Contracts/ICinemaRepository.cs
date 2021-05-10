namespace Cinema.Server.Services.Contracts
{
    using Data.ModelsContracts;
    using System.Threading.Tasks;

    public interface ICinemaRepository
    {
        Task<int> Create(ICinemaCreation model);

        Task<ICinema> GetByNameAndAddress(string name, string address);
    }
}
