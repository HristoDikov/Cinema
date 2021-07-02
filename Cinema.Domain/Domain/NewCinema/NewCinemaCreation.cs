namespace Cinema.Domain.Domain.NewCinema
{
    using Models;
    using Contracts;
    using Data.Models;
    using Services.Contracts;
    using Data.ModelsContracts;


    using System.Threading.Tasks;

    public class NewCinemaCreation : INewCinema
    {
        private readonly ICinemaService cinemaService;

        public NewCinemaCreation(ICinemaService cinemaRepository)
        {
            this.cinemaService = cinemaRepository;
        }

        public async Task<NewCinemaSummary> New(ICinemaCreation cinema)
        {
            int cinemaId = await cinemaService.Create(new Cinema(cinema.Name, cinema.Address));

            return new NewCinemaSummary(true, $"Cinema with name: '{cinema.Name}' and address: '{cinema.Address}' has been successfully created! Get your cinema id: '{cinemaId}' in order to create a room!", cinemaId);
        }
    }
}
