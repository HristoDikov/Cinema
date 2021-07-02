namespace Cinema.Server.Controllers
{
    using Models;
    using Data.Models;
    using Domain.Models;
    using Domain.Contracts;

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ProjectionController : ApiController
    {
        private readonly INewProjection newProjection;

        public ProjectionController(INewProjection newProjection)
        {
            this.newProjection = newProjection;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(ProjectionCreationModel projection)
        {
            NewProjectionSummary summary = await this.newProjection.New(new Projection(projection.RoomId, projection.MovieId, projection.StartTime));

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
