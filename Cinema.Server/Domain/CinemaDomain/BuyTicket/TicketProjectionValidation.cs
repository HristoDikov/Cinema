namespace Cinema.Server.Domain.CinemaDomain.NewTicket
{
    using Data.Dtos;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using Repositories.Contracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class TicketProjectionValidation : IBuyTicket
    {
        private readonly IProjectionRepository projectionRepository;
        private readonly IBuyTicket newTicket;

        public TicketProjectionValidation(IProjectionRepository projectionRepository, IBuyTicket newTicket)
        {
            this.projectionRepository = projectionRepository;
            this.newTicket = newTicket;
        }

        public async Task<BuyTicketSummary> Buy(ITIcketCreation ticket)
        {
            ProjectionDto proj = await this.projectionRepository.GetById(ticket.ProjectionId);

            if (proj == null)
            {
                return new BuyTicketSummary(false, $"Projection with Id: '{ticket.ProjectionId}' does not exist!");
            }

            return await this.newTicket.Buy(ticket);
        }
    }
}
