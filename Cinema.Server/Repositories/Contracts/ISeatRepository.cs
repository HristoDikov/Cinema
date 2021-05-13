namespace Cinema.Server.Repositories.Contracts
{
    using Data.Dtos;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface ISeatRepository
    {
        Task CreateSeats(IProjectionCreation projection);

        Task<SeatDto> GetSeatByProjIdRowAndCol(int rojId, short row, short col);

        Task<bool> CheckIfSeatIsBooked(int projId, short row, short col);

        Task<bool> CheckIfSeatIsBought(int projId, short row, short col);

    }
}
