namespace Cinema.Server.Domain.CinemaDomain.ReserveTicket
{
    using Data.Dtos;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using Repositories.Contracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class TicketReservationSeatValidation : ITicketReservation
    {
        private readonly ITicketReservation newTicketReservation;
        private readonly ISeatRepository seatRepository;

        public TicketReservationSeatValidation(ITicketReservation newTicketReservation, ISeatRepository seatRepository)
        {
            this.newTicketReservation = newTicketReservation;
            this.seatRepository = seatRepository;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            SeatDto seat = await this.seatRepository.GetSeatByProjIdRowAndCol(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

            if (seat == null)
            {
                return new TicketReservationSummary(false, $"There is no seat on row: '{ticket.RowNumber}' and column: '{ticket.ColNumber}'");
            }

            return await this.newTicketReservation.Reserve(ticket);
        }
    }
}
