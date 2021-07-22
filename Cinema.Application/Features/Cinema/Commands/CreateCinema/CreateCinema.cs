namespace Cinema.Application.Features.Cinema.Commands.CreateCinema
{
    using Contracts.Services;
    using Domain.Entities;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateCinema : ICreateCinema
    {
        private readonly ICinemaService cinemaService;

        public CreateCinema(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        public async Task<CreateCinemaSummary> Create(ICinemaCreation cinema)
        {
            int cinemaId = await cinemaService.Create(new Cinema(cinema.Name, cinema.Address));

            return new CreateCinemaSummary(true, $"Cinema with name: '{cinema.Name}' and address: '{cinema.Address}' has been successfully created! Get your cinema id: '{cinemaId}' in order to create a room!", cinemaId);
        }
    }
}
