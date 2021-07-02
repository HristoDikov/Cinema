namespace Cinema.Server.Controllers
{
    using Models;
    using Data.Models;
    using Domain.Models;
    using Domain.Contracts;
    using Services.Contracts;

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class CinemaController : ApiController
    {
        private readonly ICinemaService cinemaService;
        private readonly INewCinema newCinema;

        public CinemaController(ICinemaService cinemaService, INewCinema newCinema)
        {
            this.cinemaService = cinemaService;
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
