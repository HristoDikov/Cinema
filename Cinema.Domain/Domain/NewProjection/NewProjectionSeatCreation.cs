namespace Cinema.Domain.Domain.NewProjection
{
    using Models;
    using Contracts;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewProjectionSeatCreation : INewProjection
    {
        private readonly ISeatService seatService;

        public NewProjectionSeatCreation(ISeatService seatService)
        {
            this.seatService = seatService;
        }
        public async Task<NewProjectionSummary> New(IProjectionCreation projection)
        {
            await this.seatService.CreateSeats(projection);

            return new NewProjectionSummary(true, $"Projection with movieId: '{projection.MovieId}', with roomId: '{projection.RoomId}', " +
                $"with starting time: '{projection.StartTime}' has been successfully created!");
        }
    }
}
