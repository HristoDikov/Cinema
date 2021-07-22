//namespace Domain.DomainLogic.Domain.BuyTicketWithReservation
//{
//    using Models;
//    using Contracts;
//    using Data.Dtos;
//    using Services.Contracts;

//    using System.Threading.Tasks;

//    public class BuyTicketWithReservationReturnBoughtTicket : IBuyTicketWithReservation
//    {
//        private readonly ITicketService ticketService;

//        public BuyTicketWithReservationReturnBoughtTicket(ITicketService ticketService)
//        {
//            this.ticketService = ticketService;
//        }

//        public async Task<BuyTicketWithReservationSummary> BuyWithReservation(string uniqueKey)
//        {
//            TicketDto ticket = await this.ticketService.GenerateBoughtTicket(uniqueKey);

//            return new BuyTicketWithReservationSummary(true, $"The reserved ticket was bought!", ticket.TicketId, ticket);
//        }
//    }
//}
