namespace Cinema.Server.Domain.CinemaDomain.NewProjection
{
    using Data.Models;
    using Repositories.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class NewProjectionCreation : INewProjection
    {
        private readonly IProjectionRepository projectionsRepo;
        private readonly INewProjection newProjection;

        public NewProjectionCreation(IProjectionRepository projectionsRepo, INewProjection newProjection)
        {
            this.projectionsRepo = projectionsRepo;
            this.newProjection = newProjection;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation projection)
        {
            await projectionsRepo.Create(new Projection(projection.MovieId, projection.RoomId, projection.StartTime));

            return await this.newProjection.New(projection);
        }
    }
}
