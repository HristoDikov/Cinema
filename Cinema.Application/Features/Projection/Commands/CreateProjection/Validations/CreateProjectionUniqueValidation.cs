namespace Cinema.Application.Features.Projection.Commands.CreateProjection.Validations
{
    using Contracts.Services;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateProjectionUniqueValidation : ICreateProjection
    {
        private readonly IProjectionService projectionService;
        private readonly ICreateProjection createProjection;

        public CreateProjectionUniqueValidation(IProjectionService projectionService, ICreateProjection createProjection)
        {
            this.projectionService = projectionService;
            this.createProjection = createProjection;
        }

        public async Task<CreateProjectionSummary> Create(IProjectionCreation proj)
        {
            ProjectionOutputModel projection = await projectionService.Get(proj.MovieId, proj.RoomId, proj.StartTime);

            if (projection != null)
            {
                return new CreateProjectionSummary(false, "Projection already exists!");
            }

            return await createProjection.Create(proj);
        }
    }
}
