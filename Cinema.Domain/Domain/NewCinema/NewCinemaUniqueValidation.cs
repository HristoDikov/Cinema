namespace Cinema.Domain.Domain.NewCinema
{
    using Models;
    using Contracts;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewCinemaUniqueValidation : INewCinema
    {
        private readonly INewCinema newCinema;
        private readonly ICinemaService cinemaService;

        public NewCinemaUniqueValidation(INewCinema newCinema, ICinemaService cinemaRepository)
        {
            this.newCinema = newCinema;
            this.cinemaService = cinemaRepository;
        }

        public async Task<NewCinemaSummary> New(ICinemaCreation cinema)
        {
            ICinema cinemaInDb = await cinemaService.GetByNameAndAddress(cinema.Name, cinema.Address);

            if (cinemaInDb != null)
            {
                return new NewCinemaSummary(false, $"Cinema with name: '{cinemaInDb.Name}' and address: '{cinemaInDb.Address}' already exists!");
            }

            return await newCinema.New(cinema);
        }
    }
}
