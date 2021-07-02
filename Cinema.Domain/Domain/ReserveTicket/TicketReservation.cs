namespace Cinema.Domain.Domain.ReserveTicket
{
    using Models;
    using Contracts;
    using Data.Dtos;
    using Data.ModelsContracts;
    using Services.Contracts;

    using System.Threading.Tasks;

    public class TicketReservation : ITicketReservation
    {

        private readonly ITicketService ticketService;
        private readonly IProjectionService projectionService;
        private readonly ISeatService seatService;
        private readonly IRoomService roomService;
        private readonly ICinemaService cinemaService;
        private readonly IMovieService movieService;

        public TicketReservation(ITicketService ticketService, IProjectionService projectionService,
            IRoomService roomRepository, ISeatService seatService, ICinemaService cinemaService, IMovieService movieService)
        {
            this.ticketService = ticketService;
            this.projectionService = projectionService;
            this.roomService = roomRepository;
            this.seatService = seatService;
            this.cinemaService = cinemaService;
            this.movieService = movieService;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            ProjectionDto proj = await this.projectionService.GetById(ticket.ProjectionId);
            RoomDto room = await this.roomService.GetById(proj.RoomId);
            SeatDto seat = await this.seatService.GetSeatByProjIdRowAndCol(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);
            string movieName = await this.movieService.GetMovieName(proj.MovieId);
            string cinemaName = await this.cinemaService.GetCinemaName(room.CinemaId);

            TicketReservationDto reservedTicket = await this.ticketService.ReserveTicket(proj, room, seat, movieName, cinemaName, ticket.RowNumber, ticket.ColNumber);

            if (reservedTicket == null)
            {
                return new TicketReservationSummary(false, "The ticket was not reserved!");
            }

            return new TicketReservationSummary(true, $"The ticket was reserved!", reservedTicket.Id, reservedTicket);
        }
    }
}
