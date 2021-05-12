namespace Cinema.Server.Services.Contracts
{
    using Models.OutputModels;
    using Cinema.Server.Data.Dtos;

    using System.Threading.Tasks;

    public interface ITicketRepository
    {
        Task<TicketOutputModel> BuyTicket(ProjectionDto proj, RoomDto room, SeatDto seat, string movieName, string cinemaName, short rowNum, short seatNum);
    }
}
