namespace Cinema.Server.Domain.CinemaDomain.NewProjection
{
    using Data.Models;
    using Services.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class NewProjectionCreation : INewProjection
    {
        private readonly IProjectionRepository projectionsRepo;

        public NewProjectionCreation(IProjectionRepository projectionsRepo)
        {
            this.projectionsRepo = projectionsRepo;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation projection)
        {
            int newProjId = await projectionsRepo.Create(new Projection(projection.MovieId, projection.RoomId, projection.StartTime));

            return new NewProjectionSummary(true, $"Projection with Id: '{newProjId}', with movieId: '{projection.MovieId}', with roomId: '{projection.RoomId}', " +
                $"with starting time: '{projection.StartTime}' has been successfully created!");
        }
    }
}
