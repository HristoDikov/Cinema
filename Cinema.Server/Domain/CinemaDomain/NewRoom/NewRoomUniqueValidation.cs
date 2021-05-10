namespace Cinema.Server.Domain.CinemaDomain.NewRoom
{
    using CinemaDomainContracts.Models;
    using CinemaDomainContracts;
    using Data.ModelsContracts;
    using Services.Contracts;

    using System.Threading.Tasks;

    public class NewRoomUniqueValidation : INewRoom
    {
        private readonly IRoomRepository roomRepository;
        private readonly INewRoom newCinema;

        public NewRoomUniqueValidation(IRoomRepository roomRepository, INewRoom newCinema)
        {
            this.roomRepository = roomRepository;
            this.newCinema = newCinema;
        }

        public async Task<NewRoomSummary> New(IRoomCreation room)
        {
            IRoom roomFromDb = await this.roomRepository.GetByCinemaAndNumber(room.CinemaId, room.Number);

            if (roomFromDb != null)
            {
                return new NewRoomSummary(false, $"Room number: {room.Number} in cinema with Id: {room.CinemaId} has already been created!");
            }

            return await this.newCinema.New(room);
        }
    }
}
