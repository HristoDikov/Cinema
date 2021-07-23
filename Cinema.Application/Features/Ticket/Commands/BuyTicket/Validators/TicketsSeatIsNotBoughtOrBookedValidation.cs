namespace Cinema.Application.Features.Ticket.Commands.BuyTicket.Validators
{
    using Contracts.Services;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class TicketsSeatIsNotBoughtOrBookedValidation : IBuyTicket
    {
        private readonly ISeatService seatService;
        private readonly IBuyTicket newTicket;

        public TicketsSeatIsNotBoughtOrBookedValidation(ISeatService seatService, IBuyTicket newTicket)
        {
            this.seatService = seatService;
            this.newTicket = newTicket;
        }

        public async Task<BuyTicketSummary> Buy(ITIcketCreation ticket)
        {
            bool isBooked = await this.seatService.CheckIfSeatIsBooked(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);
            bool isBought = await this.seatService.CheckIfSeatIsBought(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

            if (isBooked)
            {
                return new BuyTicketSummary(false, "This seat was already booked!");
            }

            if (isBought)
            {
                return new BuyTicketSummary(false, "This seat was already bought!");
            }

            return await this.newTicket.Buy(ticket);
        }
    }
}
