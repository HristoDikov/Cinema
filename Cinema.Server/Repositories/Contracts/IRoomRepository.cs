namespace Cinema.Server.Repositories.Contracts
{
    using Data.Dtos;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface IRoomRepository
    {
        Task<int> Create(IRoomCreation room);

        Task<IRoom> GetByCinemaAndNumber(int cinemaId, int number);

        Task<RoomDto> GetById(int roomId);
    }
}
