namespace Cinema.Application.Features.Ticket.Commands.BuyTicketWithReservation
{
    using Contracts.Services;

    using System.Threading.Tasks;

    public class BuyTicketWithReservation : IBuyTicketWithReservation
    {
        private readonly ISeatService seatService;
        private readonly ITicketService ticketService;
        private readonly IBuyTicketWithReservation buyTicketWithReservation;

        public BuyTicketWithReservation(ISeatService seatService, IBuyTicketWithReservation buyTicketWithReservation, ITicketService ticketService)
        {
            this.seatService = seatService;
            this.buyTicketWithReservation = buyTicketWithReservation;
            this.ticketService = ticketService;
        }

        public async Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey)
        {
            int ticket = await this.ticketService.GetTicketId(uniqueKey);
            await this.seatService.SetSeatToBought(ticket);

            return await this.buyTicketWithReservation.BuyWithReservation(uniqueKey);
        }
    }
}
