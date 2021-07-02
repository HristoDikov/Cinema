namespace Cinema.Domain.Domain.BuyTicketWithReservation
{
    using Models;
    using Contracts;
    using Services.Contracts;

    using System.Threading.Tasks;

    public class BuyTicketWithReservationStartTimeValidation : IBuyTicketWithReservation
    {
        private readonly ITicketService ticketService;
        private readonly IProjectionService projectionService;
        private readonly IBuyTicketWithReservation buyTicketWithReservation;

        public BuyTicketWithReservationStartTimeValidation(ITicketService ticketRepository, IProjectionService projectionRepository, IBuyTicketWithReservation buyTicketWithReservation)
        {
            this.ticketService = ticketRepository;
            this.projectionService = projectionRepository;
            this.buyTicketWithReservation = buyTicketWithReservation;
        }

        public async Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey)
        {
            int projId = await this.ticketService.GetTicketProjectionId(uniqueKey);
            bool hasProjectionStarted = await this.projectionService.CheckIfProjectionHasNotStarted(projId);

            if (hasProjectionStarted)
            {
                return await this.buyTicketWithReservation.BuyWithReservation(uniqueKey);
            }

            return new BuyTicketWithReservationSummary(false, "Projection has already started!");
        }
    }
}
