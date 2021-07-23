namespace Cinema.Application.Contracts.Services
{
    using Features.Room.Commands.CreateRoom;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public interface IRoomService
    {
        Task<int> Create(IRoomCreation room);

        Task<RoomOutputModel> GetByCinemaAndNumber(int cinemaId, int number);

        Task<RoomOutputModel> GetById(int roomId);
    }
}
