namespace Cinema.Application.Contracts.Services
{
    using Features.Cinema.Commands.CreateCinema;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public interface ICinemaService
    {
        Task<int> Create(ICinemaCreation model);

        Task<CinemaOutputModel> GetByNameAndAddress(string name, string address);

        Task<CinemaOutputModel> GetById(int id);

        Task<string> GetCinemaName(int cinemaId);
    }
}
