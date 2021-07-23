namespace Cinema.Application.Contracts.Services
{
    using Features.Seat;
    using Features.Ticket.Commands.Common;
    using Features.Room.Commands.CreateRoom;
    using Features.Ticket.Commands.BuyTicket;
    using Features.Ticket.Commands.ReserveTicket;
    using Features.Projection.Commands.CreateProjection;

    using System.Threading.Tasks;

    public interface ITicketService
    {
        Task<BoughtTicketOutputModel> BuyTicket(ProjectionOutputModel proj, RoomOutputModel room, SeatOutputModel seat, string movieName, string cinemaName, short rowNum, short seatNum);

        Task<ReservedTicketOutputModel> ReserveTicket(ProjectionOutputModel projDto, RoomOutputModel roomDto, SeatOutputModel seatDto, string movieName, string cinemaName, short rowNum, short colNum);

        Task<BoughtTicketOutputModel> GenerateBoughtTicket(string uniqueKey);

        Task<int> GetTicketProjectionId(string uniqueKey);

        Task<TicketProjIdRowAndColOutputModel> GetTicketIdRowAndCol(string uniqueKey);

        Task<int> GetTicketId(string uniqueKey);
    }
}
