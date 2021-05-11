namespace Cinema.Server.Services.Contracts
{
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface IRoomRepository
    {
        Task<int> Create(IRoomCreation room);

        Task<IRoom> GetByCinemaAndNumber(int cinemaId, int number);

        Task<IRoom> GetById(int roomId);
    }
}
