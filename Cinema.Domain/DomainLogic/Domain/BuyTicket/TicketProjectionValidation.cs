//namespace Domain.DomainLogic.Domain.BuyTicket
//{
//    using Models;
//    using Data.Dtos;
//    using Contracts;
//    using Services.Contracts;
//    using Data.ModelsContracts;

//    using System.Threading.Tasks;

//    public class TicketProjectionValidation : IBuyTicket
//    {
//        private readonly IProjectionService projectionService;
//        private readonly IBuyTicket newTicket;

//        public TicketProjectionValidation(IProjectionService projectionService, IBuyTicket newTicket)
//        {
//            this.projectionService = projectionService;
//            this.newTicket = newTicket;
//        }

//        public async Task<BuyTicketSummary> Buy(ITIcketCreation ticket)
//        {
//            ProjectionDto proj = await this.projectionService.GetById(ticket.ProjectionId);

//            if (proj == null)
//            {
//                return new BuyTicketSummary(false, $"Projection with Id: '{ticket.ProjectionId}' does not exist!");
//            }

//            return await this.newTicket.Buy(ticket);
//        }
//    }
//}
