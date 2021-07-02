namespace Cinema.Services.Contracts
{
    using Data.Dtos;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface ISeatService
    {
        Task CreateSeats(IProjectionCreation projection);

        Task<SeatDto> GetSeatByProjIdRowAndCol(int rojId, short row, short col);

        Task<bool> CheckIfSeatIsBooked(int projId, short row, short col);

        Task<bool> CheckIfSeatIsBought(int projId, short row, short col);

        Task SetSeatToBought(int ticketId);
    }
}
