namespace Cinema.Domain.Domain.NewProjection
{
    using Models;
    using Contracts;
    using Data.Models;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewProjectionCreation : INewProjection
    {
        private readonly IProjectionService projectionService;
        private readonly INewProjection newProjection;

        public NewProjectionCreation(IProjectionService projectionService, INewProjection newProjection)
        {
            this.projectionService = projectionService;
            this.newProjection = newProjection;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation projection)
        {
            await projectionService.Create(new Projection(projection.MovieId, projection.RoomId, projection.StartTime));

            return await this.newProjection.New(projection);
        }
    }
}
