namespace Cinema.Application.Features.Room.Commands.CreateRoom
{
    using Contracts.Services;
    using Domain.Entities;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateRoom : ICreateRoom
    {
        private readonly IRoomService roomService;

        public CreateRoom(IRoomService roomRepository)
        {
            this.roomService = roomRepository;
        }

        public async Task<CreateRoomSummary> Create(IRoomCreation room)
        {
            int roomId = await roomService.Create(new Room(room.CinemaId, room.Number, room.SeatsPerRow, room.Rows));

            return new CreateRoomSummary(true, $"Room with number: '{room.Number}' has been successfully created! Get your room id: {roomId} in order to create a projection", roomId);
        }
    }
}
