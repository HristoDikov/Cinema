namespace Cinema.Web.Controllers
{
    using Application.Features.Projection.Commands.CreateProjection;

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectionController : ApiController
    {
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateProjectionSummary>> Create(CreateProjectionCommand command)
           => await this.Mediator.Send(command);
    }

}
