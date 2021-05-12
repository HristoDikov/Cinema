namespace Cinema.Server.Domain.CinemaDomain.NewTicket
{
    using Data.Dtos;
    using Services.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class NewTicketProjectionValidation : INewTicket
    {
        private readonly IProjectionRepository projectionRepository;
        private readonly INewTicket newTicket;

        public NewTicketProjectionValidation(IProjectionRepository projectionRepository, INewTicket newTicket)
        {
            this.projectionRepository = projectionRepository;
            this.newTicket = newTicket;
        }

        public async Task<NewTicketSummary> New(ITIcketCreation ticket)
        {
            ProjectionDto proj = await this.projectionRepository.GetById(ticket.ProjectionId);

            if (proj == null)
            {
                return new NewTicketSummary(false, $"Projection with Id: '{ticket.ProjectionId}' does not exist!");
            }

            return await this.newTicket.New(ticket);
        }
    }
}
