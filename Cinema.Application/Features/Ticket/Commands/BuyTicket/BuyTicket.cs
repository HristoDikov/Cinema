namespace Cinema.Application.Features.Ticket.Commands.BuyTicket.Validators
{
    using Features.Seat;
    using Contracts.Services;
    using Domain.EntitiesContracts;
    using Room.Commands.CreateRoom;
    using Ticket.Commands.BuyTicket;
    using Projection.Commands.CreateProjection;

    using System.Threading.Tasks;

    public class BuyTicket : IBuyTicket
    {
        private readonly ITicketService ticketService;
        private readonly IProjectionService projectionService;
        private readonly ISeatService seatService;
        private readonly IRoomService roomService;
        private readonly ICinemaService cinemaService;
        private readonly IMovieService movieService;

        public BuyTicket(ITicketService ticketService, IProjectionService projectionService,
            IRoomService roomService, ISeatService seatService, ICinemaService cinemaService, IMovieService movieService)
        {
            this.ticketService = ticketService;
            this.projectionService = projectionService;
            this.roomService = roomService;
            this.seatService = seatService;
            this.cinemaService = cinemaService;
            this.movieService = movieService;
        }

        public async Task<BuyTicketSummary> Buy(ITIcketCreation ticket)
        {
            ProjectionOutputModel proj = await this.projectionService.GetById(ticket.ProjectionId);
            RoomOutputModel room = await this.roomService.GetById(proj.RoomId);
            SeatOutputModel seat = await this.seatService.GetSeatByProjIdRowAndCol(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);
            string movieName = await this.movieService.GetMovieName(proj.MovieId);
            string cinemaName = await this.cinemaService.GetCinemaName(room.CinemaId);

            BoughtTicketOutputModel savedTicket = await this.ticketService.BuyTicket(proj, room, seat, movieName, cinemaName, ticket.RowNumber, ticket.ColNumber);

            if (savedTicket == null)
            {
                return new BuyTicketSummary(false, "The ticket was not bought!");
            }

            return new BuyTicketSummary(true, $"The ticket was bought!", savedTicket.TicketId, savedTicket);
        }
    }
}
