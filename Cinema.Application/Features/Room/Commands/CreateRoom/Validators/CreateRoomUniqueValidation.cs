namespace Cinema.Application.Features.Room.Commands.CreateRoom.Validators
{
    using Contracts.Services;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateRoomUniqueValidation : ICreateRoom
    {
        private readonly IRoomService roomService;
        private readonly ICreateRoom newCinema;

        public CreateRoomUniqueValidation(IRoomService roomRepository, ICreateRoom newCinema)
        {
            this.roomService = roomRepository;
            this.newCinema = newCinema;
        }

        public async Task<CreateRoomSummary> Create(IRoomCreation room)
        {
            RoomOutputModel roomFromDb = await this.roomService.GetByCinemaAndNumber(room.CinemaId, room.Number);

            if (roomFromDb != null)
            {
                return new CreateRoomSummary(false, $"Room number: {room.Number} in cinema with Id: {room.CinemaId} has already been created!");
            }

            return await this.newCinema.Create(room);
        }
    }
}
