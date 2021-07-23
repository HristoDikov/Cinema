namespace Cinema.Application.Features.Projection.Commands.CreateProjection
{
    using System.Threading.Tasks;
    using Domain.Entities;
    using Domain.EntitiesContracts;

    using Contracts.Services;

    public class CreateProjection : ICreateProjection
    {
        private readonly IProjectionService projectionService;
        private readonly ICreateProjection createProjection;

        public CreateProjection(IProjectionService projectionService, ICreateProjection createProjection)
        {
            this.projectionService = projectionService;
            this.createProjection = createProjection;
        }

        public async Task<CreateProjectionSummary> Create(IProjectionCreation projection)
        {
            await projectionService.Create(new Projection(projection.MovieId, projection.RoomId, projection.StartTime));

            return await this.createProjection.Create(projection);
        }
    }
}
