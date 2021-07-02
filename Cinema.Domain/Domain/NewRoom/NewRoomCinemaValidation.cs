namespace Cinema.Domain.Domain.NewRoom
{
    using Models;
    using Contracts;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewRoomCinemaValidation : INewRoom
    {
        private readonly ICinemaService cinemaService;
        private readonly INewRoom newRoom;

        public NewRoomCinemaValidation(ICinemaService cinemaRepository, INewRoom newRoom)
        {
            this.cinemaService = cinemaRepository;
            this.newRoom = newRoom;
        }

        public async Task<NewRoomSummary> New(IRoomCreation room)
        {
            ICinema cinema = await this.cinemaService.GetById(room.CinemaId);

            if (cinema == null)
            {
                return new NewRoomSummary(false, $"The room was not created. Cinema with Id: '{room.CinemaId}' does not exist!");
            }

            return await this.newRoom.New(room);
        }
    }
}
