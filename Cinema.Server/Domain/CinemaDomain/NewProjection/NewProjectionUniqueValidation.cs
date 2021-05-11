namespace Cinema.Server.Domain.CinemaDomain.NewProjection
{
    using Services.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class NewProjectionUniqueValidation : INewProjection
    {
        private readonly IProjectionRepository projectRepo;
        private readonly INewProjection newProj;

        public NewProjectionUniqueValidation(IProjectionRepository projectRepo, INewProjection newProj)
        {
            this.projectRepo = projectRepo;
            this.newProj = newProj;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation proj)
        {
            IProjection projection = await projectRepo.Get(proj.MovieId, proj.RoomId, proj.StartTime);

            if (projection != null)
            {
                return new NewProjectionSummary(false, "Projection already exists!");
            }

            return await newProj.New(proj);
        }
    }
}
