namespace Cinema.Application.Contracts.Services
{
    using Application.Seat;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public interface ISeatService
    {
        Task CreateSeats(IProjectionCreation projection);

        Task<SeatOutputModel> GetSeatByProjIdRowAndCol(int rojId, short row, short col);

        Task<bool> CheckIfSeatIsBooked(int projId, short row, short col);

        Task<bool> CheckIfSeatIsBought(int projId, short row, short col);

        Task SetSeatToBought(int ticketId);
    }
}
