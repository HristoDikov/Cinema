namespace Cinema.Domain.Contracts
{
    using Models;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface INewCinema
    {
        Task<NewCinemaSummary> New(ICinemaCreation cinema);
    }
}
