namespace Cinema.Server.Domain.CinemaDomain.NewTicket
{
    using Data.Dtos;
    using Services.Contracts;
    using Models.OutputModels;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class NewTicketCreation : INewTicket
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IProjectionRepository projectionRepository;
        private readonly ISeatRepository seatRepository;
        private readonly IRoomRepository roomRepository;
        private readonly ICinemaRepository cinemaRepository;
        private readonly IMovieRepository movieRepository;

        public NewTicketCreation(ITicketRepository ticketRepository, IProjectionRepository projectionRepository, 
            IRoomRepository roomRepository, ISeatRepository seatRepository,  ICinemaRepository cinemaRepository, IMovieRepository movieRepository)
        {
            this.ticketRepository = ticketRepository;
            this.projectionRepository = projectionRepository;
            this.roomRepository = roomRepository;
            this.seatRepository = seatRepository;
            this.cinemaRepository = cinemaRepository;
            this.movieRepository = movieRepository;
        }

        public async Task<NewTicketSummary> New(ITIcketCreation ticket)
        {
            ProjectionDto proj = await this.projectionRepository.GetById(ticket.ProjectionId);
            RoomDto room = await this.roomRepository.GetById(proj.RoomId);
            SeatDto seat = await this.seatRepository.GetSeatByProjIdRowAndCol(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);
            string movieName = await this.movieRepository.GetMovieName(proj.MovieId);
            string cinemaName = await this.cinemaRepository.GetCinemaName(room.CinemaId);

            TicketOutputModel savedTicket = await this.ticketRepository.BuyTicket(proj, room, seat, movieName, cinemaName, ticket.RowNumber, ticket.ColNumber);

            if (savedTicket == null)
            {
                return new NewTicketSummary(false, "The ticket was not bought!");
            }

            return new NewTicketSummary(true, $"The ticket was bought!", savedTicket.TicketId, savedTicket);
        }
    }
}
