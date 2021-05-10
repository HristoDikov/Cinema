namespace Cinema.Server.Domain.CinemaDomainContracts
{
    using CinemaDomainContracts.Models;
    using System.Threading.Tasks;
    using Data.ModelsContracts;

    public interface INewCinema
    {
        Task<NewCinemaSummary> New(ICinemaCreation cinema);
    }
}
