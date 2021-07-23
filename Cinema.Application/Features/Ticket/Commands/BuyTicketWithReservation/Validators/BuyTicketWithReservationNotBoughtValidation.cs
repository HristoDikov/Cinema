namespace Cinema.Application.Features.Ticket.Commands.BuyTicketWithReservation.Validators
{
    using Commands.Common;
    using Contracts.Services;

    using System.Threading.Tasks;

    public class BuyTicketWithReservationNotBoughtValidation : IBuyTicketWithReservation
    {
        private readonly IBuyTicketWithReservation buyTicketWithReservation;
        private readonly ITicketService ticketService;
        private readonly ISeatService seatService;

        public BuyTicketWithReservationNotBoughtValidation(IBuyTicketWithReservation buyTicketWithReservation, ITicketService ticketService, ISeatService seatService)
        {
            this.buyTicketWithReservation = buyTicketWithReservation;
            this.ticketService = ticketService;
            this.seatService = seatService;
        }

        public async Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey)
        {
            TicketProjIdRowAndColOutputModel ticketModel = await this.ticketService.GetTicketIdRowAndCol(uniqueKey);
            bool isBought = await this.seatService.CheckIfSeatIsBought(ticketModel.ProjId, ticketModel.Row, ticketModel.Col);

            if (isBought)
            {
                return new BuyTicketWithReservationSummary(false, "This ticket has already been bought!");
            }

            return await this.buyTicketWithReservation.BuyWithReservation(uniqueKey);
        }
    }
}
