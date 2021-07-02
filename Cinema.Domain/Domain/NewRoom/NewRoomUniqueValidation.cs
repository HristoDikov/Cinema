namespace Cinema.Domain.Domain.NewRoom
{
    using Models;
    using Contracts;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewRoomUniqueValidation : INewRoom
    {
        private readonly IRoomService roomService;
        private readonly INewRoom newCinema;

        public NewRoomUniqueValidation(IRoomService roomRepository, INewRoom newCinema)
        {
            this.roomService = roomRepository;
            this.newCinema = newCinema;
        }

        public async Task<NewRoomSummary> New(IRoomCreation room)
        {
            IRoom roomFromDb = await this.roomService.GetByCinemaAndNumber(room.CinemaId, room.Number);

            if (roomFromDb != null)
            {
                return new NewRoomSummary(false, $"Room number: {room.Number} in cinema with Id: {room.CinemaId} has already been created!");
            }

            return await this.newCinema.New(room);
        }
    }
}
