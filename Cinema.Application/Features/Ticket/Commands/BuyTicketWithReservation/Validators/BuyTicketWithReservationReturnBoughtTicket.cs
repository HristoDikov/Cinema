namespace Cinema.Application.Features.Ticket.Commands.BuyTicketWithReservation.Validators
{
    using Contracts.Services;
    using BuyTicket;
    using System.Threading.Tasks;

    public class BuyTicketWithReservationReturnBoughtTicket : IBuyTicketWithReservation
    {
        private readonly ITicketService ticketService;

        public BuyTicketWithReservationReturnBoughtTicket(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public async Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey)
        {
            BoughtTicketOutputModel ticket = await this.ticketService.GenerateBoughtTicket(uniqueKey);

            return new BuyTicketWithReservationSummary(true, $"The reserved ticket was bought!", ticket.TicketId, ticket);
        }
    }
}
