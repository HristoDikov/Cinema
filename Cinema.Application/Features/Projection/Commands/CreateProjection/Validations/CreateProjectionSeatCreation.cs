namespace Cinema.Application.Features.Projection.Commands.CreateProjection.Validations
{
    using Contracts.Services;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateProjectionSeatCreation : ICreateProjection
    {
        private readonly ISeatService seatService;

        public CreateProjectionSeatCreation(ISeatService seatService)
        {
            this.seatService = seatService;
        }
        public async Task<CreateProjectionSummary> Create(IProjectionCreation projection)
        {
            await this.seatService.CreateSeats(projection);

            return new CreateProjectionSummary(true, $"Projection with movieId: '{projection.MovieId}', with roomId: '{projection.RoomId}', " +
                $"with starting time: '{projection.StartTime}' has been successfully created!");
        }
    }
}
