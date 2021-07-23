namespace Cinema.Application.Features.Cinema.Commands.CreateCinema.Validations
{
    using Contracts.Services;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateCinemaUniqueValidation : ICreateCinema
    {
        private readonly CreateCinema createCinema;
        private readonly ICinemaService cinemaService;

        public CreateCinemaUniqueValidation(CreateCinema createCinema, ICinemaService cinemaService)
        {
            this.createCinema = createCinema;
            this.cinemaService = cinemaService;
        }

        public async Task<CreateCinemaSummary> Create(ICinemaCreation cinema)
        {
            var cinemaInDb = await cinemaService.GetByNameAndAddress(cinema.Name, cinema.Address);

            if (cinemaInDb != null)
            {
                return new CreateCinemaSummary(false, $"Cinema with name: '{cinemaInDb.Name}' and address: '{cinemaInDb.Address}' already exists!");
            }

            return await createCinema.Create(cinema);
        }
    }
}
