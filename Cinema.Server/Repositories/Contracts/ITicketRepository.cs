namespace Cinema.Server.Repositories.Contracts
{
    using Data.Dtos;
    using Models.OutputModels;

    using System.Threading.Tasks;

    public interface ITicketRepository
    {
        Task<TicketOutputModel> BuyTicket(ProjectionDto proj, RoomDto room, SeatDto seat, string movieName, string cinemaName, short rowNum, short seatNum);

        Task<TicketReservationDto> ReserveTicket(ProjectionDto projDto, RoomDto roomDto, SeatDto seatDto, string movieName, string cinemaName, short rowNum, short colNum);
    }
}
