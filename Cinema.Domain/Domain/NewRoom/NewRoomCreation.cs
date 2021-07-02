namespace Cinema.Domain.Domain.NewRoom
{
    using Models;
    using Contracts;
    using Data.Models;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewRoomCreation : INewRoom
    {
        private readonly IRoomService roomService;

        public NewRoomCreation(IRoomService roomRepository)
        {
            this.roomService = roomRepository;
        }

        public async Task<NewRoomSummary> New(IRoomCreation room)
        {
            int roomId = await roomService.Create(new Room(room.CinemaId, room.Number, room.SeatsPerRow, room.Rows));

            return new NewRoomSummary(true, $"Room with number: '{room.Number}' has been successfully created! Get your room id: {roomId} in order to create a projection", roomId);
        }
    }
}
