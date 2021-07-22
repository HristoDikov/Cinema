//namespace Cinema.Application.Contracts.Services
//{
//    using Cinema.Application.Features.Projection.Commands.CreateProjection;
//    using Cinema.Application.Seat;

//    using System.Threading.Tasks;

//    public interface ITicketService
//    {
//        Task<TicketDto> BuyTicket(ProjectionOutputModel proj, RoomDto room, SeatOutputModel seat, string movieName, string cinemaName, short rowNum, short seatNum);

//        Task<TicketReservationDto> ReserveTicket(ProjectionOutputModel projDto, RoomDto roomDto, SeatOutputModel seatDto, string movieName, string cinemaName, short rowNum, short colNum);

//        Task<TicketDto> GenerateBoughtTicket(string uniqueKey);

//        Task<int> GetTicketProjectionId(string uniqueKey);

//        Task<TicketProjIdRowAndColDto> GetTicketIdRowAndCol(string uniqueKey);

//        Task<int> GetTicketId(string uniqueKey);
//    }
//}
