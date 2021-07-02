namespace Cinema.Domain.Domain.ReserveTicket
{
    using Models;
    using Data.Dtos;
    using Contracts;
    using Services.Contracts;
    using Data.ModelsContracts;

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
            ProjectionDto proj = await this.projectionService.GetById(ticket.ProjectionId);

            if (proj == null)
            {
                return new TicketReservationSummary(false, $"Projection with Id: '{ticket.ProjectionId}' does not exist!");
            }

            return await this.newTicketReservation.Reserve(ticket);
        }
    }
}
