namespace Cinema.Application.Features.Cinema.Commands.CreateCinema
{
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public interface ICreateCinema
    {
        Task<CreateCinemaSummary> Create(ICinemaCreation cinema);
    }
}
