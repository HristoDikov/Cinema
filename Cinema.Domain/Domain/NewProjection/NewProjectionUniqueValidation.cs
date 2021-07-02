namespace Cinema.Domain.Domain.NewProjection
{
    using Models;
    using Contracts;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewProjectionUniqueValidation : INewProjection
    {
        private readonly IProjectionService projectionService;
        private readonly INewProjection newProj;

        public NewProjectionUniqueValidation(IProjectionService projectionService, INewProjection newProj)
        {
            this.projectionService = projectionService;
            this.newProj = newProj;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation proj)
        {
            IProjection projection = await projectionService.Get(proj.MovieId, proj.RoomId, proj.StartTime);

            if (projection != null)
            {
                return new NewProjectionSummary(false, "Projection already exists!");
            }

            return await newProj.New(proj);
        }
    }
}
