namespace Cinema.Application.Features.Room.Commands.CreateRoom.Validators
{
    using Contracts.Services;
    using Features.Cinema.Commands.CreateCinema;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateRoomCinemaValidation : ICreateRoom
    {
        private readonly ICinemaService cinemaService;
        private readonly ICreateRoom newRoom;

        public CreateRoomCinemaValidation(ICinemaService cinemaRepository, ICreateRoom newRoom)
        {
            this.cinemaService = cinemaRepository;
            this.newRoom = newRoom;
        }

        public async Task<CreateRoomSummary> Create(IRoomCreation room)
        {
            CinemaOutputModel cinema = await this.cinemaService.GetById(room.CinemaId);

            if (cinema == null)
            {
                return new CreateRoomSummary(false, $"The room was not created. Cinema with Id: '{room.CinemaId}' does not exist!");
            }

            return await this.newRoom.Create(room);
        }
    }
}
