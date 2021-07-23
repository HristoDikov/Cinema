namespace Cinema.Application.Features.Ticket.Commands.BuyTicket.Validators
{
    using System.Threading.Tasks;
    using Contracts.Services;
    using Domain.EntitiesContracts;
    using Projection.Commands.CreateProjection;

    public class TicketProjectionValidation : IBuyTicket
    {
        private readonly IProjectionService projectionService;
        private readonly IBuyTicket newTicket;

        public TicketProjectionValidation(IProjectionService projectionService, IBuyTicket newTicket)
        {
            this.projectionService = projectionService;
            this.newTicket = newTicket;
        }

        public async Task<BuyTicketSummary> Buy(ITIcketCreation ticket)
        {
            ProjectionOutputModel proj = await this.projectionService.GetById(ticket.ProjectionId);

            if (proj == null)
            {
                return new BuyTicketSummary(false, $"Projection with Id: '{ticket.ProjectionId}' does not exist!");
            }

            return await this.newTicket.Buy(ticket);
        }
    }
}
