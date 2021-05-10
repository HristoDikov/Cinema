namespace Cinema.Server.Domain.CinemaDomain.NewCinema
{
    using CinemaDomainContracts.Models;
    using System.Threading.Tasks;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using Services.Contracts;
    using Data.Models;

    public class NewCinemaCreation : INewCinema
    {
        private readonly ICinemaRepository cinemaRepository;

        public NewCinemaCreation(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }

        public async Task<NewCinemaSummary> New(ICinemaCreation cinema)
        {
            int cinemaId = await cinemaRepository.Create(new Cinema(cinema.Name, cinema.Address));

            return new NewCinemaSummary(true, $"Cinema with name: '{cinema.Name}' and address: '{cinema.Address}' has been successfully created! Get your cinema id: '{cinemaId}' in order to create a room!", cinemaId);
        }
    }
}
