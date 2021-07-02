namespace Cinema.Domain.Domain.ReserveTicket
{
    using Models;
    using Contracts;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class TicketReservationProjectionHasNotStartedValidation : ITicketReservation
    {
        private readonly ITicketReservation newTicketReservation;
        private readonly IProjectionService projectionService;

        public TicketReservationProjectionHasNotStartedValidation(ITicketReservation newTicketReservation, IProjectionService projectionService)
        {
            this.newTicketReservation = newTicketReservation;
            this.projectionService = projectionService;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            bool hasNotStarted = await this.projectionService.CheckIfProjectionHasNotStarted(ticket.ProjectionId);

            if (hasNotStarted)
            {
                return await this.newTicketReservation.Reserve(ticket);
            }

            return new TicketReservationSummary(false, $"The projection has already started or it starts less than 10 minutes!");
        }
    }
}
