namespace Cinema.Web.Controllers
{
    using Application.Features.Cinema.Commands.CreateCinema;

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class CinemaController : ApiController
    {

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateCinemaSummary>> Create(CreateCinemaCommand command)
            => await this.Mediator.Send(command);
    }
}
