namespace Cinema.Server.Domain.CinemaDomain.BuyTicketWithReservation
{
    using CinemaDomainContracts;
    using Repositories.Contracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class BuyTicketWithReservationStartTimeValidation : IBuyTicketWithReservation
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IProjectionRepository projectionRepository;
        private readonly IBuyTicketWithReservation buyTicketWithReservation;

        public BuyTicketWithReservationStartTimeValidation(ITicketRepository ticketRepository, IProjectionRepository projectionRepository, IBuyTicketWithReservation buyTicketWithReservation)
        {
            this.ticketRepository = ticketRepository;
            this.projectionRepository = projectionRepository;
            this.buyTicketWithReservation = buyTicketWithReservation;
        }

        public async Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey)
        {
            int projId = await this.ticketRepository.GetTicketProjectionId(uniqueKey);
            bool hasProjectionStarted = await this.projectionRepository.CheckIfProjectionHasNotStarted(projId);

            if (hasProjectionStarted)
            {
                return await this.buyTicketWithReservation.BuyWithReservation(uniqueKey);
            }

            return new BuyTicketWithReservationSummary(false, "Projection has already started!");
        }
    }
}
