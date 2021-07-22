//namespace Domain.DomainLogic.Domain.BuyTicket
//{
//    using Models;
//    using Contracts;
//    using Data.Dtos;
//    using Services.Contracts;
//    using Data.ModelsContracts;

//    using System.Threading.Tasks;

//    public class TicketsSeatValidation : IBuyTicket
//    {
//        private readonly ISeatService seatService;
//        private readonly IBuyTicket newTicket;

//        public TicketsSeatValidation(ISeatService seatService, IBuyTicket newTicket)
//        {
//            this.seatService = seatService;
//            this.newTicket = newTicket;
//        }

//        public async Task<BuyTicketSummary> Buy(ITIcketCreation ticket)
//        {
//            SeatDto seat = await this.seatService.GetSeatByProjIdRowAndCol(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

//            if (seat == null)
//            {
//                return new BuyTicketSummary(false, $"There is no seat with row number '{ticket.RowNumber}' & col number: '{ticket.ColNumber}'!");
//            }

//            return await this.newTicket.Buy(ticket);
//        }
//    }
//}
