namespace Cinema.Server.Domain.CinemaDomain.NewProjection
{
    using Services.Contracts;
    using Data.ModelsContracts;
    using Domain.CinemaDomainContracts;
    using Domain.CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class NewProjectionSeatCreation : INewProjection
    {
        private readonly ISeatRepository seatRepository;

        public NewProjectionSeatCreation(ISeatRepository seatRepository)
        {
            this.seatRepository = seatRepository;
        }
        public async Task<NewProjectionSummary> New(IProjectionCreation projection)
        {
            await this.seatRepository.CreateSeats(projection);

            return new NewProjectionSummary(true, $"Projection with movieId: '{projection.MovieId}', with roomId: '{projection.RoomId}', " +
                $"with starting time: '{projection.StartTime}' has been successfully created!");
        }
    }
}
