namespace Cinema.Application.Features.Ticket.Commands.ReserveTicket.Validators
{
    using Seat;
    using Contracts.Services;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class TicketReservationSeatValidation : ITicketReservation
    {
        private readonly ITicketReservation newTicketReservation;
        private readonly ISeatService seatRepository;

        public TicketReservationSeatValidation(ITicketReservation newTicketReservation, ISeatService seatRepository)
        {
            this.newTicketReservation = newTicketReservation;
            this.seatRepository = seatRepository;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            SeatOutputModel seat = await this.seatRepository.GetSeatByProjIdRowAndCol(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

            if (seat == null)
            {
                return new TicketReservationSummary(false, $"There is no seat on row: '{ticket.RowNumber}' and column: '{ticket.ColNumber}'");
            }

            return await this.newTicketReservation.Reserve(ticket);
        }
    }
}
