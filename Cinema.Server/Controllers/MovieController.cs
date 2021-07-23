namespace Cinema.Web.Controllers
{
    using Cinema.Application.Features.Movie.Commands.CreateMovie;

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class MovieController : ApiController
    {
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateMovieSummary>> Create(CreateMovieCommand model)
        => await this.Mediator.Send(model);
    }
}
