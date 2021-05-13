namespace Cinema.Server.Domain.CinemaDomain.ReserveTicket
{
    using Cinema.Server.Data.ModelsContracts;
    using Cinema.Server.Domain.CinemaDomainContracts;
    using Cinema.Server.Domain.CinemaDomainContracts.Models;
    using Cinema.Server.Repositories.Contracts;
    using System.Threading.Tasks;

    public class TicketReservationProjectionHasNotStartedValidation : ITicketReservation
    {
        private readonly ITicketReservation newTicketReservation;
        private readonly IProjectionRepository projectionRepository;

        public TicketReservationProjectionHasNotStartedValidation(ITicketReservation newTicketReservation, IProjectionRepository projectionRepository)
        {
            this.newTicketReservation = newTicketReservation;
            this.projectionRepository = projectionRepository;
        }

        public async Task<TicketReservationSummary> Reserve(ITIcketCreation ticket)
        {
            bool hasNotStarted = await this.projectionRepository.CheckIfProjectionHasNotStarted(ticket.ProjectionId);

            if (hasNotStarted)
            {
                return await this.newTicketReservation.Reserve(ticket);
            }

            return new TicketReservationSummary(false, $"The projection has already started or it starts less than 10 minutes!");
        }
    }
}
