namespace Cinema.Server.Domain.CinemaDomain.NewCinema
{
    using CinemaDomainContracts.Models;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using Repositories.Contracts;

    using System.Threading.Tasks;

    public class NewCinemaUniqueValidation : INewCinema
    {
        private readonly INewCinema newCinema;
        private readonly ICinemaRepository cinemaRepository;

        public NewCinemaUniqueValidation(INewCinema newCinema, ICinemaRepository cinemaRepository)
        {
            this.newCinema = newCinema;
            this.cinemaRepository = cinemaRepository;
        }

        public async Task<NewCinemaSummary> New(ICinemaCreation cinema)
        {
            ICinema cinemaInDb = await cinemaRepository.GetByNameAndAddress(cinema.Name, cinema.Address);

            if (cinemaInDb != null)
            {
                return new NewCinemaSummary(false, $"Cinema with name: '{cinemaInDb.Name}' and address: '{cinemaInDb.Address}' already exists!");
            }

            return await newCinema.New(cinema);
        }
    }
}
