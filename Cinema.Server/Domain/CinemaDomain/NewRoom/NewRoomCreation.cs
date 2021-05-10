namespace Cinema.Server.Domain.CinemaDomain.NewRoom
{
    using Data.ModelsContracts;
    using CinemaDomainContracts.Models;
    using CinemaDomainContracts;
    using System.Threading.Tasks;
    using Cinema.Server.Services.Contracts;
    using Cinema.Server.Data.Models;

    public class NewRoomCreation : INewRoom
    {
        private readonly IRoomRepository roomRepository;

        public NewRoomCreation(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public async Task<NewRoomSummary> New(IRoomCreation room)
        {
            int roomId = await roomRepository.Create(new Room(room.CinemaId, room.Number, room.SeatsPerRow, room.Rows));

            return new NewRoomSummary(true, $"Room with number: '{room.Number}' has been successfully created! Get your room id: {roomId} in order to create a projection", roomId);
        }
    }
}
