namespace Cinema.Application.Features.Ticket.Commands.ReserveTicket.Validators
{
    using Contracts.Services;
    using Domain.EntitiesContracts;
    using Projection.Commands.CreateProjection;

    using System.Threading.Tasks;

    public class TicketReservationProjectionValidation : ITicketReservation
    {
        private readonly IProjectionService projectionService;
        private readonly ITicketReservation newTicketReservation;

        public TicketReservationProjectionValidation(IProjectionService projectionService, ITicketReservation newTicketReservation)
        {
            this.projectionService = projectionService;
            this.newTicketReservation = newTicketReservation;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            ProjectionOutputModel proj = await this.projectionService.GetById(ticket.ProjectionId);

            if (proj == null)
            {
                return new TicketReservationSummary(false, $"Projection with Id: '{ticket.ProjectionId}' does not exist!");
            }

            return await this.newTicketReservation.Reserve(ticket);
        }
    }
}
