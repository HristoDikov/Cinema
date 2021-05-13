namespace Cinema.Server.Domain.CinemaDomain.ReserveTicket
{
    using Data.Dtos;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using Repositories.Contracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class TicketReservationProjectionValidation : ITicketReservation
    {
        private readonly IProjectionRepository projectionRepository;
        private readonly ITicketReservation newTicketReservation;

        public TicketReservationProjectionValidation(IProjectionRepository projectionRepository, ITicketReservation newTicketReservation)
        {
            this.projectionRepository = projectionRepository;
            this.newTicketReservation = newTicketReservation;
        }
        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            ProjectionDto proj = await this.projectionRepository.GetById(ticket.ProjectionId);

            if (proj == null)
            {
                return new TicketReservationSummary(false, $"Projection with Id: '{ticket.ProjectionId}' does not exist!");
            }

            return await this.newTicketReservation.Reserve(ticket);
        }
    }
}
