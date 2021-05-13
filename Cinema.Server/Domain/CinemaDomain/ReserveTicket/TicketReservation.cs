namespace Cinema.Server.Domain.CinemaDomain.ReserveTicket
{
    using Data.Dtos;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;
    using Repositories.Contracts;
    using System.Threading.Tasks;

    public class TicketReservation : ITicketReservation
    {

        private readonly ITicketRepository ticketRepository;
        private readonly IProjectionRepository projectionRepository;
        private readonly ISeatRepository seatRepository;
        private readonly IRoomRepository roomRepository;
        private readonly ICinemaRepository cinemaRepository;
        private readonly IMovieRepository movieRepository;

        public TicketReservation(ITicketRepository ticketRepository, IProjectionRepository projectionRepository,
            IRoomRepository roomRepository, ISeatRepository seatRepository, ICinemaRepository cinemaRepository, IMovieRepository movieRepository)
        {
            this.ticketRepository = ticketRepository;
            this.projectionRepository = projectionRepository;
            this.roomRepository = roomRepository;
            this.seatRepository = seatRepository;
            this.cinemaRepository = cinemaRepository;
            this.movieRepository = movieRepository;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            ProjectionDto proj = await this.projectionRepository.GetById(ticket.ProjectionId);
            RoomDto room = await this.roomRepository.GetById(proj.RoomId);
            SeatDto seat = await this.seatRepository.GetSeatByProjIdRowAndCol(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);
            string movieName = await this.movieRepository.GetMovieName(proj.MovieId);
            string cinemaName = await this.cinemaRepository.GetCinemaName(room.CinemaId);

            TicketReservationDto reservedTicket = await this.ticketRepository.ReserveTicket(proj, room, seat, movieName, cinemaName, ticket.RowNumber, ticket.ColNumber);

            if (reservedTicket == null)
            {
                return new TicketReservationSummary(false, "The ticket was not reserved!");
            }

            return new TicketReservationSummary(true, $"The ticket was reserved!", reservedTicket.Id, reservedTicket);
        }
    }
}
