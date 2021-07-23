namespace Cinema.Application.Features.Projection.Commands.CreateProjection.Validations
{
    using Contracts.Services;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateProjectionRoomValidation : ICreateProjection
    {
        private readonly IRoomService roomService;
        private readonly ICreateProjection createProjection;

        public CreateProjectionRoomValidation(IRoomService roomService, ICreateProjection createProjection)
        {
            this.roomService = roomService;
            this.createProjection = createProjection;
        }

        public async Task<CreateProjectionSummary> Create(IProjectionCreation proj)
        {
            var room = await roomService.GetById(proj.RoomId);

            if (room == null)
            {
                return new CreateProjectionSummary(false, $"Room with id: '{proj.RoomId}' does not exist!");
            }

            return await createProjection.Create(proj);
        }
    }
}
