namespace Cinema.Server.Domain.CinemaDomain.NewRoom
{
    using CinemaDomainContracts.Models;
    using CinemaDomainContracts;
    using Data.ModelsContracts;
    using Services.Contracts;

    using System.Threading.Tasks;

    public class NewRoomCinemaValidation : INewRoom
    {
        private readonly ICinemaRepository cinemaRepository;
        private readonly INewRoom newRoom;

        public NewRoomCinemaValidation(ICinemaRepository cinemaRepository, INewRoom newRoom)
        {
            this.cinemaRepository = cinemaRepository;
            this.newRoom = newRoom;
        }

        public async Task<NewRoomSummary> New(IRoomCreation room)
        {
            ICinema cinema = await this.cinemaRepository.GetById(room.CinemaId);

            if (cinema == null)
            {
                return new NewRoomSummary(false, $"The room was not created. Cinema with Id: '{room.CinemaId}' does not exist!");
            }

            return await this.newRoom.New(room);
        }
    }
}
