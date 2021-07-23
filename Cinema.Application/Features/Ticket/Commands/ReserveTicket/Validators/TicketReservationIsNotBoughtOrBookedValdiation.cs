namespace Cinema.Application.Features.Ticket.Commands.ReserveTicket.Validators
{
    using Contracts.Services;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class TicketReservationIsNotBoughtOrBookedValdiation : ITicketReservation
    {
        private readonly ISeatService seatService;
        private readonly ITicketReservation newTicketReservation;

        public TicketReservationIsNotBoughtOrBookedValdiation(ISeatService seatService, ITicketReservation newTicketReservation)
        {
            this.seatService = seatService;
            this.newTicketReservation = newTicketReservation;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            bool isBooked = await this.seatService.CheckIfSeatIsBooked(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);
            bool isBought = await this.seatService.CheckIfSeatIsBought(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

            if (isBooked)
            {
                return new TicketReservationSummary(false, "This seat was already booked!");
            }

            if (isBought)
            {
                return new TicketReservationSummary(false, "This seat was already bought!");
            }

            return await this.newTicketReservation.Reserve(ticket);
        }
    }
}
