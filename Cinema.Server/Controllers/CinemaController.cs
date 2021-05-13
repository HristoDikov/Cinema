namespace Cinema.Server.Controllers
{
    using Domain.CinemaDomainContracts.Models;
    using Domain.CinemaDomainContracts;
    using Cinema.Server.Models;
    using Repositories.Contracts;
    using Data.Models;

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CinemaController : ApiController
    {
        private readonly ICinemaRepository cinemaRepository;
        private readonly INewCinema newCinema;

        public CinemaController(ICinemaRepository cinemaRepository, INewCinema newCinema)
        {
            this.cinemaRepository = cinemaRepository;
            this.newCinema = newCinema;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(CinemaCreationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Input not correct.");
            }

            NewCinemaSummary summary = await newCinema.New(new Cinema(model.Name, model.Address));

            if (summary.IsCreated)
            {
                return Ok(summary.Message);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}
